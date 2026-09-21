# Etap 7 — migracja obsługi błędów

W aplikacji Web Forms znajduje się strona `CustomerDetails.aspx`, która wyświetla szczegóły wybranego klienta.

Przeanalizuj istniejącą implementację:

- `WebFormsApp/CustomerDetails.aspx`
- `WebFormsApp/CustomerDetails.aspx.cs`

a następnie zmigruj ją do aplikacji Blazor.

## Zadanie 15 — szczegóły klienta i stany błędu

Utwórz komponent:

`Components/Pages/CustomerDetails.razor`

dostępny pod adresem:

`/customers/{id}`

Przykład:

`/customers/5`

Do pobierania danych wykorzystaj istniejący `ICustomerService` dostarczany przez Dependency Injection.

### Wymagania

Komponent powinien:

- pobierać identyfikator klienta z adresu URL,
- asynchronicznie pobierać klienta za pomocą `ICustomerService`,
- podczas pobierania danych wyświetlać **Ładowanie...**,
- po poprawnym pobraniu wyświetlać nazwę i adres e-mail klienta,
- jeżeli klient o podanym Id nie istnieje, wyświetlać **Nie znaleziono klienta.**,
- jeżeli podczas pobierania danych wystąpi błąd, wyświetlać:

```
Nie udało się pobrać danych.

[Spróbuj ponownie]
```

- przycisk **Spróbuj ponownie** powinien ponownie wykonać operację pobierania danych,
- podczas ponownego pobierania powinien być widoczny stan **Ładowanie...**,
- nie wyświetlać użytkownikowi treści wyjątku ani stack trace,
- nie używać JavaScriptu.

### Zastanów się

- Co w Blazorze zastępuje `Request.QueryString["id"]`?
- Czy potrzebujesz `IsPostBack`?
- Co zastępuje `LoadingPanel.Visible = true`?
- Co zastępuje `CustomerPanel.Visible = true`?
- Czy nadal potrzebujesz `NameLabel.Text = customer.Name`?
- Gdzie przechowywany jest pobrany `Customer`?
- Jak reprezentujesz informację o trwającym ładowaniu?
- Jak reprezentujesz informację o błędzie?
- Czy brak klienta i błąd podczas pobierania danych to ten sam stan?

## Część 2 — nieoczekiwany wyjątek

Po wykonaniu pierwszej części zmodyfikuj aplikację tak, aby podczas wyświetlania szczegółów klienta można było zasymulować nieoczekiwany wyjątek.

Zaobserwuj:

- co zobaczy użytkownik,
- co pojawi się w logach aplikacji,
- jak zachowuje się interaktywna część aplikacji po wystąpieniu wyjątku.

Następnie wykorzystaj `ErrorBoundary`, aby zabezpieczyć odpowiedni fragment UI.

W przypadku nieobsłużonego wyjątku użytkownik powinien zobaczyć przyjazny komunikat zamiast uszkodzonego interfejsu.

## Warunek ukończenia

Po migracji powinny działać cztery scenariusze:

```
/customers/{id}
        │
        ├── pobieranie ─────► Ładowanie...
        │
        ├── znaleziony ─────► dane klienta
        │
        ├── brak klienta ───► Nie znaleziono klienta
        │
        └── błąd ───────────► komunikat + Spróbuj ponownie
```

Dodatkowo aplikacja powinna posiadać odpowiednią granicę obsługi nieoczekiwanych błędów za pomocą `ErrorBoundary`.

## Demo — obsługa nieoczekiwanego błędu

Porównaj `WebFormsApp/ErrorDemo.aspx` z `/error-demo` w Blazorze.

W Web Forms kliknięcie **Wygeneruj błąd** kończy cały request:

```
ErrorDemo.aspx
      │
      │ PostBack
      ▼
ErrorButton_Click
      │
      X exception
      │
      ▼
Page_Error
      │
      ▼
Response.Redirect
      │
      ▼
Error.aspx
```

W Blazorze `ErrorBoundary` zastępuje tylko fragment UI. Reszta strony i circuit zostają.

| Web Forms | Blazor |
| --- | --- |
| `Page_Error` | `ErrorBoundary` |
| granica związana ze stroną/requestem | granica w drzewie komponentów |
| błąd podczas PostBack | błąd komponentu interaktywnego |
| `Response.Redirect` | `ErrorContent` |
| przejście na `Error.aspx` | zastąpienie fragmentu UI |
| kolejny request tworzy stronę ponownie | komponenty działają w ramach circuitu |
