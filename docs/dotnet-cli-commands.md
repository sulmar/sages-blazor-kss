# Podstawowe komendy .NET CLI

Ściągawka na salę: przypięcie SDK, utworzenie aplikacji Blazor Interactive Server i dodanie jej do solution.

## SDK

```bash
dotnet --list-sdks
dotnet new globaljson --sdk-version 10.0.100
```

`global.json` przypina wersję SDK w katalogu rozwiązania. Dzięki temu cała grupa buduje tym samym SDK.

## Nowy projekt Blazor

```bash
dotnet new blazor -o BlazorApp --int Server
```

`--int` to skrót `--interactivity`. `Server` oznacza Interactive Server (SignalR).

```bash
dotnet new blazor --help
```

pokazuje pozostałe opcje szablonu, gdy trzeba je sprawdzić na żywo.

## Solution

```bash
dotnet sln add BlazorApp
```

Dodaje projekt do istniejącego pliku `.sln` w bieżącym katalogu, np. `WebFormsBlazorComparison.sln`.

```bash
dotnet sln list
```

wypisuje, co już jest w solution.

## Uruchomienie

```bash
dotnet run --project BlazorApp
dotnet watch --project BlazorApp
```

`run` startuje aplikację. `watch` uruchamia ją ponownie po zmianie plików.

## Build

```bash
dotnet build
```
