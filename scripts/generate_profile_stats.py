#!/usr/bin/env python3
from __future__ import annotations

import argparse
import html
import json
import os
import re
import sys
from pathlib import Path
from typing import Any
from urllib.error import HTTPError
from urllib.parse import quote, urlencode
from urllib.request import Request, urlopen


API_BASE_URL = "https://api.github.com"
API_VERSION = "2022-11-28"
USER_AGENT = "yljeferson-profile-stats"

LANGUAGE_COLORS = {
    "Batchfile": "#C1F12E",
    "C": "#555555",
    "C#": "#178600",
    "C++": "#f34b7d",
    "CSS": "#663399",
    "Dart": "#00B4AB",
    "Go": "#00ADD8",
    "HTML": "#e34c26",
    "Java": "#b07219",
    "JavaScript": "#f1e05a",
    "Kotlin": "#A97BFF",
    "PHP": "#4F5D95",
    "PowerShell": "#012456",
    "Python": "#3572A5",
    "Ruby": "#701516",
    "Rust": "#dea584",
    "Shell": "#89e051",
    "TSQL": "#e38c00",
    "TypeScript": "#3178c6",
    "VBScript": "#15dcdc",
}

FALLBACK_COLORS = (
    "#ff5779",
    "#7957d5",
    "#1d87da",
    "#2ea043",
    "#d29922",
    "#db61a2",
)

STAT_ICONS = (
    "M8 .25a.75.75 0 01.673.418l1.882 3.815 4.21.612a.75.75 0 01.416 1.279l-3.046 2.97.719 4.192a.75.75 0 01-1.088.791L8 12.347l-3.766 1.98a.75.75 0 01-1.088-.79l.72-4.194L.818 6.374a.75.75 0 01.416-1.28l4.21-.611L7.327.668A.75.75 0 018 .25zm0 2.445L6.615 5.5a.75.75 0 01-.564.41l-3.097.45 2.24 2.184a.75.75 0 01.216.664l-.528 3.084 2.769-1.456a.75.75 0 01.698 0l2.77 1.456-.53-3.084a.75.75 0 01.216-.664l2.24-2.183-3.096-.45a.75.75 0 01-.564-.41L8 2.694v.001z",
    "M1.643 3.143L.427 1.927A.25.25 0 000 2.104V5.75c0 .138.112.25.25.25h3.646a.25.25 0 00.177-.427L2.715 4.215a6.5 6.5 0 11-1.18 4.458.75.75 0 10-1.493.154 8.001 8.001 0 101.6-5.684zM7.75 4a.75.75 0 01.75.75v2.992l2.028.812a.75.75 0 01-.557 1.392l-2.5-1A.75.75 0 017 8.25v-3.5A.75.75 0 017.75 4z",
    "M7.177 3.073L9.573.677A.25.25 0 0110 .854v4.792a.25.25 0 01-.427.177L7.177 3.427a.25.25 0 010-.354zM3.75 2.5a.75.75 0 100 1.5.75.75 0 000-1.5zm-2.25.75a2.25 2.25 0 113 2.122v5.256a2.251 2.251 0 11-1.5 0V5.372A2.25 2.25 0 011.5 3.25zM11 2.5h-1V4h1a1 1 0 011 1v5.628a2.251 2.251 0 101.5 0V5A2.5 2.5 0 0011 2.5zm1 10.25a.75.75 0 111.5 0 .75.75 0 01-1.5 0zM3.75 12a.75.75 0 100 1.5.75.75 0 000-1.5z",
    "M8 1.5a6.5 6.5 0 100 13 6.5 6.5 0 000-13zM0 8a8 8 0 1116 0A8 8 0 010 8zm9 3a1 1 0 11-2 0 1 1 0 012 0zm-.25-6.25a.75.75 0 00-1.5 0v3.5a.75.75 0 001.5 0v-3.5z",
    "M2 2.5A2.5 2.5 0 014.5 0h8.75a.75.75 0 01.75.75v12.5a.75.75 0 01-.75.75h-2.5a.75.75 0 110-1.5h1.75v-2h-8a1 1 0 00-.714 1.7.75.75 0 01-1.072 1.05A2.495 2.495 0 012 11.5v-9zm10.5-1V9h-8c-.356 0-.694.074-1 .208V2.5a1 1 0 011-1h8zM5 12.25v3.25a.25.25 0 00.4.2l1.45-1.087a.25.25 0 01.3 0L8.6 15.7a.25.25 0 00.4-.2v-3.25a.25.25 0 00-.25-.25h-3.5a.25.25 0 00-.25.25z",
)


class ApiError(RuntimeError):
    def __init__(self, status: int, message: str) -> None:
        super().__init__(message)
        self.status = status


class GitHubApi:
    def __init__(self, token: str | None = None) -> None:
        self.token = token.strip() if token else None

    def get(
        self, path: str, params: dict[str, Any] | None = None
    ) -> tuple[Any, dict[str, str]]:
        query = f"?{urlencode(params)}" if params else ""
        request = Request(
            f"{API_BASE_URL}{path}{query}",
            headers={
                "Accept": "application/vnd.github+json",
                "X-GitHub-Api-Version": API_VERSION,
                "User-Agent": USER_AGENT,
            },
        )
        if self.token:
            request.add_header("Authorization", f"Bearer {self.token}")

        try:
            with urlopen(request, timeout=30) as response:
                payload = json.loads(response.read().decode("utf-8"))
                headers = dict(response.headers.items())
        except HTTPError as error:
            try:
                details = json.loads(error.read().decode("utf-8")).get("message", "")
            except (json.JSONDecodeError, UnicodeDecodeError):
                details = ""
            raise ApiError(error.code, details or f"GitHub API retornou {error.code}") from error

        return payload, headers

    def paginate(self, path: str, params: dict[str, Any] | None = None) -> list[Any]:
        items: list[Any] = []
        page = 1
        while True:
            page_params = dict(params or {})
            page_params.update({"page": page, "per_page": 100})
            payload, _ = self.get(path, page_params)
            if not isinstance(payload, list):
                raise RuntimeError(f"Resposta inesperada ao consultar {path}")
            items.extend(payload)
            if len(payload) < 100:
                return items
            page += 1


def select_api(
    username: str, profile_token: str | None, public_token: str | None
) -> tuple[GitHubApi, bool]:
    if profile_token:
        private_api = GitHubApi(profile_token)
        try:
            viewer, _ = private_api.get("/user")
            if str(viewer.get("login", "")).casefold() == username.casefold():
                return private_api, True
            print(
                "PROFILE_STATS_TOKEN pertence a outra conta; usando somente dados públicos.",
                file=sys.stderr,
            )
        except ApiError as error:
            if error.status not in {401, 403}:
                raise
            print(
                "PROFILE_STATS_TOKEN ausente, inválido ou revogado; usando somente dados públicos.",
                file=sys.stderr,
            )

    return GitHubApi(public_token), False


def list_repositories(api: GitHubApi, username: str, authenticated_user: bool) -> list[dict[str, Any]]:
    if authenticated_user:
        repositories = api.paginate(
            "/user/repos",
            {"affiliation": "owner", "sort": "full_name", "direction": "asc"},
        )
    else:
        repositories = api.paginate(
            f"/users/{quote(username, safe='')}/repos",
            {"type": "owner", "sort": "full_name", "direction": "asc"},
        )

    return [
        repository
        for repository in repositories
        if str(repository.get("owner", {}).get("login", "")).casefold()
        == username.casefold()
        and not repository.get("fork", False)
    ]


def repository_api_path(repository: dict[str, Any]) -> str:
    owner = quote(str(repository["owner"]["login"]), safe="")
    name = quote(str(repository["name"]), safe="")
    return f"/repos/{owner}/{name}"


def count_repository_commits(api: GitHubApi, repository: dict[str, Any]) -> int:
    try:
        payload, headers = api.get(
            f"{repository_api_path(repository)}/commits",
            {"per_page": 1},
        )
    except ApiError as error:
        if error.status in {404, 409}:
            return 0
        raise

    if not payload:
        return 0

    link_header = headers.get("Link", "")
    last_page = re.search(r"[?&]page=(\d+)>; rel=\"last\"", link_header)
    return int(last_page.group(1)) if last_page else 1


def search_count(api: GitHubApi, query: str) -> int:
    payload, _ = api.get("/search/issues", {"q": query, "per_page": 1})
    return int(payload.get("total_count", 0))


def collect_stats(
    api: GitHubApi, repositories: list[dict[str, Any]], username: str
) -> dict[str, Any]:
    language_totals: dict[str, int] = {}
    commit_count = 0

    for repository in repositories:
        languages, _ = api.get(f"{repository_api_path(repository)}/languages")
        for language, byte_count in languages.items():
            language_totals[language] = language_totals.get(language, 0) + int(byte_count)
        commit_count += count_repository_commits(api, repository)

    profile, _ = api.get(f"/users/{quote(username, safe='')}")

    return {
        "repository_count": len(repositories),
        "private_count": sum(bool(repository.get("private")) for repository in repositories),
        "stars": sum(int(repository.get("stargazers_count", 0)) for repository in repositories),
        "commits": commit_count,
        "pull_requests": search_count(api, f"author:{username} type:pr user:{username}"),
        "issues": search_count(api, f"author:{username} type:issue user:{username}"),
        "followers": int(profile.get("followers", 0)),
        "languages": language_totals,
    }


def format_number(value: int) -> str:
    return f"{value:,}".replace(",", ".")


def calculate_rank(stats: dict[str, Any]) -> tuple[str, float]:
    exponential_cdf = lambda value: 1 - 2**-value
    log_normal_cdf = lambda value: value / (1 + value)

    weighted_score = (
        2 * exponential_cdf(int(stats["commits"]) / 1000)
        + 3 * exponential_cdf(int(stats["pull_requests"]) / 50)
        + exponential_cdf(int(stats["issues"]) / 25)
        + 4 * log_normal_cdf(int(stats["stars"]) / 50)
        + log_normal_cdf(int(stats["followers"]) / 10)
    )
    percentile = max(0.0, min(100.0, (1 - weighted_score / 12) * 100))
    thresholds = (1, 12.5, 25, 37.5, 50, 62.5, 75, 87.5, 100)
    levels = ("S", "A+", "A", "A-", "B+", "B", "B-", "C+", "C")
    level = next(level for threshold, level in zip(thresholds, levels) if percentile <= threshold)
    return level, percentile


def render_profile_stats(stats: dict[str, Any]) -> str:
    rows = (
        ("Total de estrelas", stats["stars"]),
        ("Total de commits", stats["commits"]),
        ("Total de PRs", stats["pull_requests"]),
        ("Total de Issues", stats["issues"]),
        ("Repositórios analisados", stats["repository_count"]),
    )
    row_markup = "\n".join(
        f'''    <g transform="translate(25 {index * 25})">
      <svg class="icon" viewBox="0 0 16 16" width="16" height="16">
        <path fill-rule="evenodd" d="{STAT_ICONS[index]}"/>
      </svg>
      <text class="stat" x="25" y="12.5">{html.escape(label)}:</text>
      <text class="stat value" x="274" y="12.5">{format_number(int(value))}</text>
    </g>'''
        for index, (label, value) in enumerate(rows)
    )
    rank_level, rank_percentile = calculate_rank(stats)
    rank_offset = 251.32741228718345 * rank_percentile / 100
    description = (
        f"Total de estrelas: {stats['stars']}, total de commits: {stats['commits']}, "
        f"total de pull requests: {stats['pull_requests']}, total de issues: {stats['issues']}, "
        f"repositórios analisados: {stats['repository_count']}, classificação: {rank_level}."
    )

    return f'''<svg width="467" height="195" viewBox="0 0 467 195" fill="none"
  xmlns="http://www.w3.org/2000/svg" role="img" aria-labelledby="stats-title stats-desc">
  <title id="stats-title">Estatísticas do GitHub</title>
  <desc id="stats-desc">{html.escape(description)}</desc>
  <style>
    .header {{ font: 600 18px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #7957d5; }}
    .stat {{ font: 600 14px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #539bf5; }}
    .value {{ font-weight: 700; }}
    .icon {{ fill: #ff3860; }}
    .rank-text {{ font: 800 24px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #539bf5; }}
  </style>
  <rect x="0.5" y="0.5" width="466" height="194" rx="4.5" fill="transparent"
    stroke="#e4e2e2" stroke-opacity="0"/>
  <text class="header" x="25" y="35">Estatísticas</text>
  <g transform="translate(0 55)">
    <g transform="translate(390.5 47.5)">
      <circle cx="-10" cy="8" r="40" fill="none" stroke="#7957d5" stroke-width="6" stroke-opacity="0.2"/>
      <circle cx="-10" cy="8" r="40" fill="none" stroke="#7957d5" stroke-width="6"
        stroke-linecap="round" stroke-opacity="0.8" stroke-dasharray="251.327"
        stroke-dashoffset="{rank_offset:.3f}" transform="rotate(-90 -10 8)"/>
      <text class="rank-text" x="-10" y="9" text-anchor="middle" dominant-baseline="middle">{rank_level}</text>
    </g>
{row_markup}
  </g>
</svg>
'''


def render_top_languages(stats: dict[str, Any]) -> str:
    languages = sorted(
        stats["languages"].items(), key=lambda item: (-item[1], item[0].casefold())
    )[:6]
    if not languages:
        items_markup = (
            '  <text class="empty" x="150" y="80" text-anchor="middle">'
            "Nenhuma linguagem encontrada</text>"
        )
        progress_markup = ""
        description = "Nenhuma linguagem encontrada."
    else:
        displayed_total = sum(byte_count for _, byte_count in languages)
        percentages = [byte_count / displayed_total * 100 for _, byte_count in languages]
        bar_width = 250.0
        current_x = 25.0
        progress_parts: list[str] = []
        item_parts: list[str] = []

        for index, ((language, _), percentage) in enumerate(zip(languages, percentages)):
            color = LANGUAGE_COLORS.get(language, FALLBACK_COLORS[index])
            segment_width = bar_width * percentage / 100
            progress_parts.append(
                f'    <rect x="{current_x:.2f}" y="25" width="{segment_width:.2f}" '
                f'height="8" fill="{color}"/>'
            )
            current_x += segment_width

            column = index // 3
            row = index % 3
            x = 25 + column * 150
            y = 50 + row * 25
            display_name = language if len(language) <= 18 else f"{language[:17]}..."
            percentage_text = f"{percentage:.2f}".replace(".", ",")
            item_parts.append(
                f'''  <g transform="translate({x} {y})">
    <circle cx="5" cy="6" r="5" fill="{color}"/>
    <text class="language" x="15" y="10">{html.escape(display_name)} {percentage_text}%</text>
  </g>'''
            )

        progress_markup = "\n".join(progress_parts)
        items_markup = "\n".join(item_parts)
        description = ", ".join(
            f"{language} {percentage:.2f}%"
            for (language, _), percentage in zip(languages, percentages)
        )
        description = f"{description}."

    return f'''<svg width="300" height="135" viewBox="0 0 300 135" fill="none"
  xmlns="http://www.w3.org/2000/svg" role="img" aria-labelledby="langs-title langs-desc">
  <title id="langs-title">Linguagens mais utilizadas</title>
  <desc id="langs-desc">{html.escape(description)}</desc>
  <style>
    .language {{ font: 600 11px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #1d87da; }}
    .empty {{ font: 600 13px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #1d87da; }}
  </style>
  <defs>
    <clipPath id="language-progress-mask">
      <rect x="25" y="25" width="250" height="8" rx="5"/>
    </clipPath>
  </defs>
  <rect x="0.5" y="0.5" width="299" height="134" rx="4.5" fill="transparent"
    stroke="#e4e2e2" stroke-opacity="0"/>
  <g clip-path="url(#language-progress-mask)">
{progress_markup}
  </g>
{items_markup}
</svg>
'''


def write_svg(path: Path, content: str) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(content, encoding="utf-8", newline="\n")


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Gera cartões SVG para o README do perfil.")
    parser.add_argument(
        "--username",
        default=os.getenv("PROFILE_USERNAME", "yljeferson"),
        help="Usuário do GitHub usado nas estatísticas.",
    )
    parser.add_argument(
        "--output-dir",
        type=Path,
        default=Path("assets"),
        help="Diretório onde os cartões serão gravados.",
    )
    return parser.parse_args()


def main() -> int:
    args = parse_args()
    profile_token = os.getenv("PROFILE_STATS_TOKEN")
    public_token = os.getenv("PUBLIC_API_TOKEN")
    api, authenticated_user = select_api(args.username, profile_token, public_token)
    repositories = list_repositories(api, args.username, authenticated_user)
    stats = collect_stats(api, repositories, args.username)

    write_svg(args.output_dir / "profile-stats.svg", render_profile_stats(stats))
    write_svg(args.output_dir / "top-languages.svg", render_top_languages(stats))

    mode = "completo" if stats["private_count"] else "público"
    print(f"Cartões gerados no modo {mode} para {stats['repository_count']} repositórios.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
