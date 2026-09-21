# Etap 4 — JavaScript interop

Rozbuduj aplikację Customers o funkcjonalności korzystające z API przeglądarki:

- potwierdzenie usunięcia klienta,
- automatyczne ustawienie kursora w polu formularza.

Po poprzednich etapach mamy m.in.:

```
BlazorApp
└── Components
    ├── Pages
    │   ├── Customers.razor
    │   ├── CustomerCreate.razor
    │   ├── CustomerEdit.razor
    │   ├── CustomerFilter.razor
    │   └── UserPreferences.razor
    │
    └── CustomerForm.razor
```

## Zadanie 7 — potwierdzenie usunięcia

Rozbuduj `Customers.razor` o możliwość usuwania klienta.

Przy każdym kliencie dodaj:

`Edytuj | Usuń`

Po kliknięciu **Usuń** aplikacja powinna wyświetlić standardowe okno przeglądarki:

```
Czy na pewno chcesz usunąć klienta Jan Kowalski?

[OK] [Anuluj]
```

Klient powinien zostać usunięty tylko po potwierdzeniu.

### CustomerService

Do serwisu dodaj lub udostępnij:

```csharp
public Task DeleteAsync(int id)
{
    // ...
}
```

### Wymagania

Rozwiązanie powinno:

- dodać przycisk **Usuń** do listy klientów,
- przed usunięciem poprosić użytkownika o potwierdzenie,
- wykorzystać JavaScript `confirm()`,
- wywołać JavaScript z kodu C#,
- anulować operację po wybraniu Anuluj,
- wywołać `CustomerService.DeleteAsync()` po wybraniu OK,
- po usunięciu odświeżyć listę klientów.

### Zastanów się

- Gdzie wykonuje się `confirm()`?
- Czy C# działający na serwerze może bezpośrednio wywołać Browser API?
- Do czego służy `IJSRuntime`?
- Dlaczego wywołanie JS jest asynchroniczne?
- Jak JavaScript może zwrócić `true`/`false` do C#?

## Zadanie 8 — focus po otwarciu formularza

Po wejściu na:

`/customers/create`

kursor powinien automatycznie znaleźć się w polu **Nazwa**.

Czyli użytkownik może od razu zacząć pisać.

### Wymagania

Rozwiązanie powinno:

- ustawić focus na polu Name,
- zrobić to po wyrenderowaniu formularza,
- nie wyszukiwać elementu przez `document.getElementById`,
- wykorzystać referencję do elementu,
- wykonać operację tylko przy pierwszym renderowaniu.

### Zastanów się

- Czy element `<input>` istnieje podczas `OnInitializedAsync()`?
- Kiedy mamy pewność, że UI zostało już wyrenderowane?
- Do czego służy `OnAfterRenderAsync()`?
- Co oznacza `firstRender`?
- Jak uzyskać referencję do elementu DOM?
