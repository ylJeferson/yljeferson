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

    return {
        "repository_count": len(repositories),
        "private_count": sum(bool(repository.get("private")) for repository in repositories),
        "stars": sum(int(repository.get("stargazers_count", 0)) for repository in repositories),
        "commits": commit_count,
        "pull_requests": search_count(api, f"author:{username} type:pr user:{username}"),
        "issues": search_count(api, f"author:{username} type:issue user:{username}"),
        "languages": language_totals,
    }


def format_number(value: int) -> str:
    return f"{value:,}".replace(",", ".")


def data_scope_label(private_count: int) -> str:
    return "Dados públicos e privados" if private_count else "Somente dados públicos"


def render_profile_stats(stats: dict[str, Any]) -> str:
    rows = (
        ("Repositórios analisados", stats["repository_count"]),
        ("Total de estrelas", stats["stars"]),
        ("Total de commits", stats["commits"]),
        ("Pull requests", stats["pull_requests"]),
        ("Issues", stats["issues"]),
    )
    row_markup = "\n".join(
        f'''    <g transform="translate(24 {62 + index * 21})">
      <circle cx="5" cy="-4" r="4" fill="#ff3860"/>
      <text class="label" x="18" y="0">{html.escape(label)}</text>
      <text class="value" x="352" y="0" text-anchor="end">{format_number(int(value))}</text>
    </g>'''
        for index, (label, value) in enumerate(rows)
    )
    scope = data_scope_label(int(stats["private_count"]))
    description = (
        f"{stats['repository_count']} repositórios, {stats['commits']} commits, "
        f"{stats['pull_requests']} pull requests e {stats['issues']} issues. {scope}."
    )

    return f'''<svg width="400" height="180" viewBox="0 0 400 180" fill="none"
  xmlns="http://www.w3.org/2000/svg" role="img" aria-labelledby="stats-title stats-desc">
  <title id="stats-title">Estatísticas do GitHub</title>
  <desc id="stats-desc">{html.escape(description)}</desc>
  <style>
    .header {{ font: 600 18px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #7957d5; }}
    .label {{ font: 600 13px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #539bf5; }}
    .value {{ font: 700 13px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #539bf5; }}
    .scope {{ font: 400 10px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #1d87da; }}
  </style>
  <rect x="0.5" y="0.5" width="399" height="179" rx="4.5" fill="transparent"
    stroke="#e4e2e2" stroke-opacity="0"/>
  <text class="header" x="24" y="32">Estatísticas</text>
  <line x1="24" y1="43" x2="376" y2="43" stroke="#7957d5" stroke-opacity="0.22"/>
{row_markup}
  <text class="scope" x="24" y="169">{html.escape(scope)}</text>
</svg>
'''


def render_top_languages(stats: dict[str, Any]) -> str:
    languages = sorted(
        stats["languages"].items(), key=lambda item: (-item[1], item[0].casefold())
    )[:6]
    scope = data_scope_label(int(stats["private_count"]))

    if not languages:
        items_markup = (
            '  <text class="empty" x="200" y="92" text-anchor="middle">'
            "Nenhuma linguagem encontrada</text>"
        )
        progress_markup = ""
        description = f"Nenhuma linguagem encontrada. {scope}."
    else:
        displayed_total = sum(byte_count for _, byte_count in languages)
        percentages = [byte_count / displayed_total * 100 for _, byte_count in languages]
        bar_width = 352.0
        current_x = 24.0
        progress_parts: list[str] = []
        item_parts: list[str] = []

        for index, ((language, _), percentage) in enumerate(zip(languages, percentages)):
            color = LANGUAGE_COLORS.get(language, FALLBACK_COLORS[index])
            segment_width = bar_width * percentage / 100
            progress_parts.append(
                f'    <rect x="{current_x:.2f}" y="24" width="{segment_width:.2f}" '
                f'height="8" fill="{color}"/>'
            )
            current_x += segment_width

            column = index // 3
            row = index % 3
            x = 24 + column * 190
            y = 66 + row * 29
            display_name = language if len(language) <= 18 else f"{language[:17]}..."
            percentage_text = f"{percentage:.2f}".replace(".", ",")
            item_parts.append(
                f'''  <g transform="translate({x} {y})">
    <circle cx="5" cy="-4" r="5" fill="{color}"/>
    <text class="language" x="16" y="0">{html.escape(display_name)} {percentage_text}%</text>
  </g>'''
            )

        progress_markup = "\n".join(progress_parts)
        items_markup = "\n".join(item_parts)
        description = ", ".join(
            f"{language} {percentage:.2f}%"
            for (language, _), percentage in zip(languages, percentages)
        )
        description = f"{description}. {scope}."

    return f'''<svg width="400" height="180" viewBox="0 0 400 180" fill="none"
  xmlns="http://www.w3.org/2000/svg" role="img" aria-labelledby="langs-title langs-desc">
  <title id="langs-title">Linguagens mais utilizadas</title>
  <desc id="langs-desc">{html.escape(description)}</desc>
  <style>
    .language {{ font: 600 11px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #1d87da; }}
    .empty {{ font: 600 13px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #1d87da; }}
    .scope {{ font: 400 10px "Segoe UI", Ubuntu, "Helvetica Neue", sans-serif; fill: #1d87da; }}
  </style>
  <defs>
    <clipPath id="language-progress-mask">
      <rect x="24" y="24" width="352" height="8" rx="4"/>
    </clipPath>
  </defs>
  <rect x="0.5" y="0.5" width="399" height="179" rx="4.5" fill="transparent"
    stroke="#e4e2e2" stroke-opacity="0"/>
  <g clip-path="url(#language-progress-mask)">
{progress_markup}
  </g>
{items_markup}
  <text class="scope" x="24" y="169">{html.escape(scope)}</text>
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

    scope = "públicos e privados" if stats["private_count"] else "somente públicos"
    print(f"Cartões gerados com dados {scope} de {stats['repository_count']} repositórios.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
