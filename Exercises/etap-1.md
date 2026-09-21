# Etap 1 — lista i dodawanie

Docelowo w aplikacji powstaną między innymi:

```
BlazorApp
└── Pages
    ├── Customers.razor
    └── CustomerCreate.razor
```

## Zadanie 1 — lista klientów

Przeanalizuj działanie:

- `WebFormsApp/Customers.aspx`
- `WebFormsApp/Customers.aspx.cs`

Następnie utwórz w aplikacji Blazor komponent `Customers.razor`.

Strona powinna być dostępna pod:

`/customers`

### Wymagania

Strona powinna:

- automatycznie pobierać klientów po wejściu,
- korzystać z `CustomerService` przez Dependency Injection,
- wyświetlać „Ładowanie klientów...” podczas pobierania,
- wyświetlać klientów w tabeli,
- wyświetlać „Brak klientów”, gdy lista jest pusta,
- obsługiwać błąd pobierania,
- posiadać przycisk „Odśwież”,
- blokować przycisk podczas pobierania.

Nie używaj JavaScriptu.

### Zastanów się

- Co w Blazorze zastąpi `Page_Load`?
- Czy potrzebujesz odpowiednika `IsPostBack`?
- Co zastąpi `GridView`?
- Czy potrzebujesz `DataBind()`?
- Gdzie przechowywana będzie lista klientów?
- Jak zastąpić `Panel.Visible`?
- Jak zablokować przycisk podczas pobierania?

## Zadanie 2 — dodawanie klienta

Po ukończeniu listy przeanalizuj:

- `WebFormsApp/CustomerCreate.aspx`
- `WebFormsApp/CustomerCreate.aspx.cs`

Utwórz:

`CustomerCreate.razor`

Strona powinna być dostępna pod:

`/customers/create`

### Wymagania

Formularz powinien:

- umożliwiać podanie nazwy klienta,
- umożliwiać podanie adresu e-mail,
- korzystać z mechanizmu formularzy Blazora,
- korzystać z model bindingu,
- wymagać podania nazwy,
- wymagać poprawnego adresu e-mail,
- wyświetlać komunikaty walidacyjne,
- zapisywać klienta przez `CustomerService`,
- blokować przycisk podczas zapisu,
- podczas zapisu wyświetlać tekst „Zapisywanie...”,
- po poprawnym zapisie przechodzić do `/customers`.

Dodaj również na stronie `/customers` link lub przycisk umożliwiający przejście do formularza dodawania klienta.

### Zastanów się

- Co zastąpi `<asp:TextBox>`?
- Co zastąpi `TextBox.Text`?
- Co zastąpi `RequiredFieldValidator`?
- Gdzie powinna znaleźć się walidacja danych?
- Co zastąpi `Page.IsValid`?
- Jak zastąpić `Response.Redirect()`?
- Jak reprezentować stan „trwa zapisywanie”?

## Oczekiwany efekt końcowy

Po wykonaniu obu zadań aplikacja powinna umożliwiać przepływ:

```
/customers
     │
     │ Dodaj klienta
     ▼
/customers/create
     │
     │ Zapisz
     ▼
/customers
```
