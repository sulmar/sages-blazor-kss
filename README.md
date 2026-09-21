# Przykłady ze szkolenia Web Forms i Blazor

## Wprowadzenie

Witaj w repozytorium z materiałami do szkolenia Web Forms i Blazor.

Repozytorium zawiera gotowe zaplecze — aplikacje ASP.NET Web Forms, które są punktem odniesienia na sali i punktem wyjścia do ćwiczeń. Dzięki temu na szkoleniu zajmujemy się Blazorem, a nie pisaniem od zera rzeczy, które i tak już umiesz.

Aplikację Blazor (`BlazorApp`) utworzysz samodzielnie podczas szkolenia.

Do rozpoczęcia tego kursu potrzebujesz następujących rzeczy:

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- .NET Framework 4.8 (aplikacje Web Forms)
- Edytor: Visual Studio 2026, JetBrains Rider albo Visual Studio Code z rozszerzeniem C# Dev Kit

## Przygotowanie

Sklonuj repozytorium Git

```bash
git clone https://github.com/sulmar/sages-blazor-kss.git
cd sages-blazor-kss
```

Zaufaj certyfikatowi deweloperskiemu (jednorazowo, potrzebne do HTTPS)

```bash
dotnet dev-certs https --trust
```

Aplikacje Web Forms otwórz w Visual Studio — wymagają .NET Framework 4.8 i IIS Express.

## Struktura repozytorium

| Katalog | Zawartość |
| --- | --- |
| `Training.WebForms` | Katalog produktów w ASP.NET Web Forms — punkt odniesienia na sali |
| `WebFormsApp` | Aplikacja Customers w Web Forms — punkt wyjścia do ćwiczeń |
| `Exercises` | Zadania do wykonania na szkoleniu |
| `docs` | Materiały pomocnicze (roadmapa, mapa myśli, porównanie) |

Roadmapa: [roadmap.xmind](docs/roadmap.xmind) · [roadmap.md](docs/roadmap.md)

Mapa myśli: [mindmap-blazor-webforms](docs/mindmap-blazor-webforms.md)

Szczegółowe porównanie: [Porównanie WebForms i Blazor](docs/porownanie-webforms-blazor.md)

Ćwiczenie: [Migracja Customers do Blazora](Exercises/README.md)

## Harmonogram

| Dzień | Bloki | Zakres | Rezultat |
| --- | --- | --- | --- |
| 1 | 1–5 | Model mentalny, lista, nawigacja, edycja, formularze | Uczestnik rozumie zmianę modelu programowania |
| 2 | 6–9 | Komponenty, dodawanie, interaktywność, stan UI | Działający katalog produktów |
| 3 | 10–12 | Architektura, JS interop, Server vs WASM | Zmigrowany fragment aplikacji |

| Blok | Temat | Zakres |
| --- | --- | --- |
| 1 | Zmiana modelu mentalnego | Licznik → PostBack → ViewState → SignalR → renderowanie |
| 2 | Pierwszy ekran | Lista produktów → GridView kontra Razor → dane → DI → async |
| 3 | Nawigacja | Podgląd produktu → routing → route parameters |
| 4 | Edycja | Binding → zapis → NavigationManager |
| 5 | Formularze | EditForm → DataAnnotations → ValidationMessage → ValidationSummary → FluentValidation jako bonus |
| 6 | Komponentowość | ProductForm → `[Parameter]` → `EventCallback` → ponowne wykorzystanie |
| 7 | Dodawanie produktu | Ten sam ProductForm → Create vs Edit |
| 8 | Interaktywność | wyszukiwanie → filtrowanie → sortowanie → ewentualnie QuickGrid |
| 9 | Stan UI | loading → empty → error → disabled podczas zapisu |
| 10 | Architektura aplikacji | DI → lifetime serwisów → gdzie trzymać logikę → czego nie pakować do `.razor` |
| 11 | JavaScript | JS interop — pokazać, że istnieje, ale nie budować Blazora „po javascriptowemu” |
| 12 | Server vs WASM | Powrót do architektury: ten sam komponent jako Interactive WebAssembly |
