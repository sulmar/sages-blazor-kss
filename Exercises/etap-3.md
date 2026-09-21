# Etap 3 — stan aplikacji i preferencje użytkownika

Rozbuduj aplikację Customers o:

- współdzielony stan pomiędzy komponentami,
- zapamiętywanie ustawień w ramach circuitu,
- trwałą preferencję przechowywaną w przeglądarce.

Po etapie 2 aplikacja wygląda mniej więcej tak:

```
BlazorApp
└── Components
    ├── Pages
    │   ├── Customers.razor
    │   ├── CustomerCreate.razor
    │   └── CustomerEdit.razor
    │
    └── CustomerForm.razor
```

## Zadanie 5 — współdzielony stan

Dodaj możliwość ustawienia maksymalnego Id klienta wyświetlanego na liście.

Celowo użyj prostego filtra, żeby nie dokładać nowej domeny biznesowej.

Utwórz stronę:

```
Components
└── Pages
    └── CustomerFilter.razor
```

dostępną pod:

`/customer-filter`

Użytkownik powinien móc ustawić np.:

```
Maksymalne Id klienta: [ 10 ]

[Zastosuj]
```

Po przejściu na `/customers` lista powinna uwzględniać tę wartość.

### Wymagania

Stan filtra powinien znajdować się we współdzielonym serwisie:

`CustomerSession`

Serwis zarejestruj jako:

```csharp
builder.Services.AddScoped<CustomerSession>();
```

Nie przekazuj wartości:

- przez query string,
- przez parametr komponentu,
- przez `localStorage`,
- przez bazę danych.

`CustomerFilter` oraz `Customers` mają korzystać z tej samej instancji serwisu przez DI.

### Zastanów się

- Gdzie przechować wartość, skoro potrzebują jej dwa komponenty?
- Czy pole w `CustomerFilter.razor` wystarczy?
- Jaki lifetime DI zastosować?
- Co oznacza `Scoped` w Interactive Server?
- Czy jest to odpowiednik Web Forms `Session`?
- Co stanie się ze stanem po odświeżeniu aplikacji?

### Eksperyment

To obowiązkowa część ćwiczenia.

1. Ustaw filtr.
2. Przejdź na `/customers`.
3. Sprawdź, czy filtr działa.
4. Wróć na `/customer-filter`.
5. Sprawdź, czy wartość nadal istnieje.
6. Naciśnij F5.

Pytanie:

Co stało się ze stanem i dlaczego?

To prowadzi bezpośrednio do następnego zadania.

## Zadanie 6 — preferencje użytkownika

Dodaj osobną stronę:

```
Components
└── Pages
    └── UserPreferences.razor
```

dostępną pod:

`/preferences`

Nie modyfikuj `CustomerSession`. To jest drugi, osobny przykład innego rodzaju stanu.

Strona pozwala ustawić:

```
Liczba klientów na stronie: [ 25 ]

[Zapisz]
```

Wartość `PageSize` powinna zostać zapisana za pomocą:

`ProtectedSessionStorage`

Zarejestruj serwis w kontenerze DI, analogicznie do materiałów szkoleniowych.

### Wymagania

Strona powinna:

- pozwalać podać `PageSize`,
- zapisywać wartość w `ProtectedSessionStorage`,
- odczytywać wcześniej zapisaną wartość,
- po F5 nadal pokazywać zapisaną wartość,
- używać C# do komunikacji z browser storage,
- nie używać własnego kodu JavaScript.

### Eksperyment 2

Po wykonaniu zadania:

1. Ustaw `PageSize = 25`.
2. Zapisz.
3. Naciśnij F5.
4. Sprawdź wartość.
5. Otwórz DevTools.
6. Przejdź do Application → Session Storage.
7. Znajdź zapisaną wartość.

Zauważ ważną różnicę:

```
CustomerSession
      ↓
serwer / circuit

ProtectedSessionStorage
      ↓
browser sessionStorage
```

## Zadanie dodatkowe

Na razie zapisz `PageSize` w przeglądarce. W etapie 5 lista klientów wykorzysta tę wartość do paginacji.
