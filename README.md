# WebForms i Blazor

## Skrócony harmonogram

| Dzień | Bloki | Zakres | Rezultat |
| --- | --- | --- | --- |
| 1 | 1–5 | Model mentalny, lista, nawigacja, edycja, formularze | Uczestnik rozumie zmianę modelu programowania |
| 2 | 6–9 | Komponenty, dodawanie, interaktywność, stan UI | Działający katalog produktów |
| 3 | 10–12 | Architektura, JS interop, Server vs WASM | Zmigrowany fragment aplikacji OrderDesk |

Roadmapa (XMind): [roadmap.xmind](docs/roadmap.xmind) · [roadmap.md](docs/roadmap.md)

Mapa myśli (XMind): [mindmap-blazor-webforms](docs/mindmap-blazor-webforms.md)

Szczegółowe porównanie: [Porównanie WebForms i Blazor](docs/porownanie-webforms-blazor.md)

## Ćwiczenia

[Ćwiczenie — migracja Customers do Blazora](Exercises/README.md)

Uczestnik tworzy nową aplikację `BlazorApp` i przenosi funkcjonalność z `WebFormsApp` (lista, dodawanie, edycja, wspólny `CustomerForm`, stan, JS interop, wyszukiwanie i paginacja). Rozwiązanie: [Exercises/Solutions](Exercises/Solutions).

## Bloki szkolenia

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
