# Etap 2 — edycja i komponenty

Rozbuduj aplikację z poprzedniego ćwiczenia o:

- edycję klienta,
- routing z parametrem,
- współdzielony formularz klienta,
- komunikację pomiędzy komponentami.

Po etapie 1 masz:

```
BlazorApp
└── Components
    └── Pages
        ├── Customers.razor
        └── CustomerCreate.razor
```

Punktem odniesienia będzie istniejąca implementacja Web Forms:

```
WebFormsApp
├── Customers.aspx
├── Customers.aspx.cs
├── CustomerCreate.aspx
├── CustomerCreate.aspx.cs
├── CustomerEdit.aspx
└── CustomerEdit.aspx.cs
```

## Zadanie 3 — edycja klienta

Przeanalizuj istniejącą stronę Web Forms:

- `WebFormsApp/CustomerEdit.aspx`
- `WebFormsApp/CustomerEdit.aspx.cs`

W `CustomerService` dostępne są:

- `GetAsync(int id)`
- `UpdateAsync(Customer customer)`

Utwórz w `BlazorApp`:

```
Components
└── Pages
    └── CustomerEdit.razor
```

Strona powinna być dostępna pod:

`/customers/edit/5`

gdzie `5` oznacza identyfikator klienta.

### Wymagania

Strona powinna:

- pobierać `Id` klienta z adresu,
- pobierać klienta za pomocą `CustomerService`,
- wyświetlać stan ładowania,
- obsługiwać sytuację, gdy klient nie istnieje,
- wyświetlać dane klienta w formularzu,
- walidować formularz,
- zapisywać zmiany przez `UpdateAsync`,
- blokować przycisk podczas zapisu,
- po zapisie przechodzić do `/customers`.

Na stronie `Customers.razor` dodaj przy każdym kliencie link **Edytuj** prowadzący do odpowiedniego klienta.

### Zastanów się

- Jak przekazać `Id` w routingu Blazora?
- Do czego służy `[Parameter]`?
- Co zastąpi `Request.QueryString["id"]`?
- Kiedy należy pobrać klienta?
- Czy potrzebujesz `IsPostBack`?
- Dlaczego w Web Forms `!IsPostBack` było tutaj ważne?
- Co stanie się w Blazorze po zmianie właściwości obiektu `customer`?

## Zadanie 4 — usuń duplikację formularza

Po wykonaniu zadania 3 masz:

- `CustomerCreate.razor`
- `CustomerEdit.razor`

i oba komponenty zawierają praktycznie ten sam formularz.

### Problem

Porównaj:

- `CustomerCreate.razor`
- `CustomerEdit.razor`

Zwróć uwagę na powtarzający się kod odpowiedzialny za:

- pola formularza,
- binding,
- walidację,
- przycisk zapisu.

### Zadanie

Wydziel wspólny formularz do komponentu:

```
BlazorApp
└── Components
    └── CustomerForm.razor
```

Po zmianach struktura powinna wyglądać mniej więcej tak:

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

### Wymagania dla CustomerForm

Komponent powinien otrzymywać model klienta jako parametr.

Powinien również umożliwiać rodzicowi określenie tekstu przycisku:

```razor
<CustomerForm
    Customer="customer"
    SubmitText="Dodaj klienta" />
```

Ten sam komponent powinien działać dla edycji:

```razor
<CustomerForm
    Customer="customer"
    SubmitText="Zapisz zmiany" />
```

Komponent powinien także informować rodzica o poprawnym wysłaniu formularza.

Czyli rodzic powinien móc zrobić:

```razor
<CustomerForm
    Customer="customer"
    SubmitText="Dodaj klienta"
    OnValidSubmit="Create" />
```

oraz:

```razor
<CustomerForm
    Customer="customer"
    SubmitText="Zapisz zmiany"
    OnValidSubmit="Update" />
```

### Zastanów się

- Co oznaczają `[Parameter]` i `EventCallback`?
- Kto powinien wywoływać `CreateAsync` i `UpdateAsync` — formularz czy strona?
- Dlaczego Create i Edit mogą używać tego samego komponentu?

## Kryteria ukończenia etapu 2

Na końcu uczestnik powinien mieć działający przepływ:

```
/customers
     │
     ├── Dodaj ──────► /customers/create
     │
     └── Edytuj ─────► /customers/edit/{id}
```

Create i Edit korzystają z tego samego:

`CustomerForm`
