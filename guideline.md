# Diretrizes do Projeto

Estas diretrizes complementam as diretrizes globais do Codex e se aplicam somente a este repositório.

## Escopo

- Manter a apresentação do perfil público do GitHub, seus recursos visuais e o acervo técnico reutilizável.
- Aplicações independentes e configurações globais do Codex ficam fora deste projeto.

## Divisão de responsabilidades

| Chat | Responsabilidade | Arquivos e diretórios |
| --- | --- | --- |
| `readme` | Apresentação e documentação do perfil; integração e geração das estatísticas; documentação das responsabilidades aprovadas. | `readme.md`, `guideline.md`, `scripts/generate_profile_stats.py` e `.github/workflows/update-profile-stats.yml`. |
| `assets` | Imagens, logos, GIFs, páginas auxiliares e cabeçalhos de distribuição. | Recursos mantidos manualmente em `assets/`, incluindo `404.html` e `_headers`. |
| `acervo_tecnico` | Exemplos, referências e templates reutilizáveis, organizados por tecnologia. | `acervo_tecnico/`. |

Alterações que cruzem essas fronteiras devem considerar as referências e os arquivos relacionados no mesmo conjunto de alterações.

## Estatísticas do perfil

- O chat `readme` mantém o gerador Python, o workflow e a integração dos cartões no perfil.
- `assets/profile-stats.svg` e `assets/top-languages.svg` são resultados gerados, sob responsabilidade funcional do chat `readme`, embora estejam em `assets/`.
- Altere a geração no script e regenere os cartões; não edite esses SVGs manualmente.
- Mudanças nos nomes ou caminhos dos cartões devem atualizar o script, o workflow e as referências no `readme.md`.
- A geração depende da API do GitHub; a atualização automática depende do GitHub Actions e das permissões do workflow. A configuração dos tokens opcionais é documentada no `readme.md`.

## Templates e páginas distribuídas

| Referência mantida por `acervo_tecnico` | Cópia distribuída mantida por `assets` |
| --- | --- |
| `acervo_tecnico/HTML/Template - 404 Celestial.html` | `assets/404.html` |

- O template Celestial é a referência para o conteúdo da página 404 distribuída.
- Ao alterar esse conteúdo, sincronize os dois arquivos no mesmo conjunto de alterações e verifique sua correspondência.
- O chat `assets` mantém os recursos e cabeçalhos necessários à distribuição dessa página.

## Documentação

- O `readme.md` mantém sua função de apresentação do perfil e documenta a estrutura, a execução e as dependências do projeto no formato global obrigatório.
- As responsabilidades permanentes aprovadas ficam neste `guideline.md`; o README pode referenciá-lo sem duplicar as diretrizes.
