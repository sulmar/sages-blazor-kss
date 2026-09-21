# Etap 5 — wyszukiwanie i paginacja

Rozbuduj istniejącą stronę `/customers` o:

- wyszukiwanie,
- paginację,
- obsługę loading, empty, error,
- blokowanie UI podczas operacji,
- asynchroniczne pobieranie danych.

Po wcześniejszych etapach mamy już:

```
BlazorApp
└── Components
    ├── Pages
    │   ├── Customers.razor
    │   ├── CustomerCreate.razor
    │   ├── CustomerEdit.razor
    │   └── ...
    └── CustomerForm.razor
```

Tym razem nie tworzymy nowej strony. Rozbudowujemy `Customers.razor`.

## Zadanie 10 — wyszukiwanie klientów

Aktualna lista pobiera wszystkich klientów.

Dodaj pole:

```
Szukaj: [                    ] [Szukaj]
```

Po wpisaniu `kowalski` lista powinna pokazywać tylko pasujących klientów.

### Rozbudowa serwisu

Dostajesz metodę:

```csharp
public async Task<List<Customer>> SearchAsync(string? search)
{
    // ...
}
```

Nie implementuj dostępu do bazy. Skup się na Blazorze.

### Wymagania

Rozbuduj `Customers.razor` tak, aby:

- użytkownik mógł podać tekst wyszukiwania,
- kliknięcie **Szukaj** pobierało dane asynchronicznie,
- podczas pobierania był widoczny stan loading,
- podczas pobierania przycisk był zablokowany,
- pusta lista wyświetlała odpowiedni komunikat,
- błąd pobierania był obsłużony,
- ponowne wyszukanie zastępowało poprzednie wyniki.

### Zastanów się

- Gdzie przechowywać tekst wyszukiwania?
- Czy tekst wpisany do inputa jest stanem komponentu?
- Czy potrzebujemy PostBack?
- Co powoduje ponowne renderowanie komponentu?
- Czy trzeba wywołać `DataBind()`?
- Czy po zakończeniu `await` Blazor zaktualizuje UI?

## Zadanie 11 — paginacja

Następnie rozbuduj listę o paginację.

Interfejs może wyglądać tak:

```
Szukaj: [ kowalski ] [Szukaj]

Jan Kowalski
Adam Kowalski
Anna Kowalska

[Poprzednia]   Strona 2 z 5   [Następna]
```

Serwis może udostępniać:

```csharp
public Task<CustomerPage> GetPageAsync(
    string? search,
    int page,
    int pageSize)
{
    // ...
}
```

Model:

```csharp
public class CustomerPage
{
    public List<Customer> Items { get; set; } = [];

    public int TotalCount { get; set; }
}
```

### Wymagania

Dodaj do `Customers.razor`:

- numer aktualnej strony,
- `PageSize`,
- przycisk **Poprzednia**,
- przycisk **Następna**,
- informację o aktualnej stronie.

Nie pozwalaj przejść:

- przed pierwszą stronę,
- za ostatnią stronę.

Po zmianie wyszukiwanego tekstu wróć do strony 1.

## Zadanie 12 — wykorzystaj preferencję z poprzedniego etapu

Połącz ćwiczenia.

W etapie 3 zapisywałeś `PageSize` w `ProtectedSessionStorage`.

Teraz `Customers.razor` powinien użyć tej wartości do paginacji.

Jeżeli użytkownik ustawi:

`PageSize = 25`

lista klientów powinna wyświetlać maksymalnie 25 rekordów na stronę.

Dzięki temu wcześniejsze ćwiczenie z browser storage zaczyna mieć realne zastosowanie.

### Wymagania

- odczytaj `PageSize` z `ProtectedSessionStorage`,
- przekaż tę wartość do `GetPageAsync`,
- jeżeli preferencja nie została jeszcze zapisana, użyj rozsądnej wartości domyślnej,
- po zmianie preferencji na `/preferences` lista na `/customers` ma respektować nowy rozmiar strony.

### Zastanów się

- Kiedy można odczytać `ProtectedSessionStorage`?
- Czy `OnInitializedAsync` wystarczy?
- Co zrobić, gdy użytkownik nie zapisał jeszcze preferencji?

