# Porównanie WebForms i Blazor

## Architektura

To rozwiązanie zestawia dwie architektury na tym samym przykładzie **Counter**: żądanie HTTP i nowa strona w ASP.NET Web Forms oraz żyjący komponent w Blazor Interactive Server.

- Web Forms: `Training.WebForms/Counter.aspx`, `Counter.aspx.cs`, `Counter.aspx.designer.cs`
- Blazor: `Training.Blazor/Components/Pages/Counter.razor`

## 1. Strony

Najważniejsza różnica: WebForms kieruje żądanie do fizycznego pliku na podstawie nazwy pliku, a Blazor używa routingu komponentów ustawionego w `@page`.

| WebForms | Blazor |
| --- | --- |
| Strona jest plikiem `.aspx` | Strona jest komponentem `.razor` |
| Adres wynika z położenia pliku | Adres określa dyrektywa `@page` |
| Klasa dziedziczy po `Page` | Komponent dziedziczy po `ComponentBase` |
| Wymaga formularza `runat="server"` | Nie wymaga formularza serwerowego |
| Zawiera pełną strukturę HTML | Layout dostarcza strukturę dokumentu |
| Logika znajduje się w code-behind | Logika może być w sekcji `@code` |
| Obsługa żądania tworzy nową stronę | Interaktywna instancja komponentu może pozostać aktywna |
| Nawigacja prowadzi do pliku `.aspx` | Router wybiera komponent na podstawie trasy |

## 2. Stan

Web Forms traktuje każde żądanie jak nową stronę: serwer tworzy instancję `Page`, odtwarza stan z `__VIEWSTATE` i odsyła cały HTML. W Blazor Interactive Server komponent żyje między zdarzeniami — kliknięcie idzie przez SignalR, a do przeglądarki wracają tylko zmiany interfejsu.

| WebForms | Blazor Interactive Server |
|---|---|
| Strona jest tworzona przy każdym żądaniu | Komponent żyje między zdarzeniami |
| Stan wraca w `__VIEWSTATE` | Stan pozostaje w instancji komponentu |
| Kliknięcie wykonuje HTTP POST | Kliknięcie wysyła zdarzenie przez SignalR |
| Serwer renderuje całą odpowiedź HTML | Blazor wysyła zmiany interfejsu |
| `asp:Button` i `OnClick` | zwykły `button` i `@onclick` |
| `.aspx`, `.aspx.cs`, `.designer.cs` | jeden plik `.razor` |
| `Page_Load` i cykl życia strony | metody cyklu życia komponentu |

## 3. Komponenty

User Control w Web Forms to osobna kontrolka wpięta w cykl życia strony: rejestracja, `ID`, `runat="server"` i stan w ViewState. Komponent Blazor jest zwykłym znacznikiem `.razor` z własną instancją, parametrami `[Parameter]` i komunikacją przez `EventCallback`.

| WebForms User Control                         | Blazor Component                     |
| --------------------------------------------- | ------------------------------------ |
| `.ascx`, `.ascx.cs`, `.designer.cs`           | Jeden plik `.razor`                  |
| Wymaga `<%@ Register %>`                      | Wymaga `@using` lub `_Imports.razor` |
| Wymaga `ID` i `runat="server"`                | Używany jak zwykły znacznik HTML     |
| Stan kontrolki jest przechowywany w ViewState | Stan pozostaje w instancji komponentu |
| Parametry są publicznymi właściwościami        | Parametry mają atrybut `[Parameter]` |
| Zdarzenia używają `OnClick` i `EventArgs`      | Zdarzenia używają `@onclick`         |
| Kliknięcie powoduje postback całej strony     | Aktualizuje się fragment interfejsu  |
| Kontrolka uczestniczy w cyklu życia strony     | Komponent ma własny cykl życia       |
| Komunikacja z rodzicem używa zdarzeń .NET      | Komunikacja używa `EventCallback`    |
| Każda instancja wymaga unikalnego `ID`         | Każde użycie tworzy osobną instancję |

Na szkoleniu najpierw zostaje `ProductCreate.razor` z wklejonym `EditForm`. Potem osobny plac zabaw `ComponentDemo` pokazuje, że ten sam markup można wyciągnąć do `ProductForm` i dokładać parametry na oczach grupy: najpierw `Product`, potem `SubmitText`, potem `OnValidSubmit`.

- Punkt wyjścia: `Training.Blazor/Components/Pages/ProductCreate.razor`
- Plac zabaw: `Training.Blazor/Components/Pages/ComponentDemo.razor` (`/component-demo`)
- Komponent: `Training.Blazor/Components/Shared/ProductForm.razor`
- Create po wyciągnięciu: `Training.Blazor/Components/Pages/ProductCreateWithComponent.razor`
- Edit po wyciągnięciu: `Training.Blazor/Components/Pages/ProductEditWithComponent.razor`

Ten sam `ProductForm` obsługuje create i edit: różni się `SubmitText` oraz to, czy strona woła `CreateAsync` czy `UpdateAsync` po załadowaniu produktu z trasy `{Id:int}`.

| Krok na sali | Parametr |
| --- | --- |
| `<ProductForm Product="product" />` | `[Parameter] public Product Product` |
| `SubmitText="Dodaj produkt"` | `[Parameter] public string SubmitText` |
| `OnValidSubmit="Save"` | `[Parameter] public EventCallback OnValidSubmit` |

`ProductCreate` zostaje nietknięty, żeby wcześniejszy przykład formularza nie rozjechał się w trakcie eksperymentów.

## 4. Zdarzenia

W Web Forms dziecko zgłasza `EventHandler<T>` z własną klasą `EventArgs`, a rodzic obsługuje to podczas postbacku. W Blazor Interactive Server dziecko wywołuje `EventCallback<T>` przez SignalR, a para `Value` + `ValueChanged` daje `@bind-Value`.

| WebForms | Blazor Interactive Server |
| --- | --- |
| `event EventHandler<T>` | `EventCallback<T>` |
| Własna klasa `EventArgs` | Wartość może być przekazana bezpośrednio |
| Rodzic używa `OnValueChanged` | Rodzic używa `ValueChanged` |
| Zdarzenie następuje podczas postbacku | Zdarzenie przechodzi przez SignalR |
| Rodzic aktualizuje kontrolkę serwerową | Zmiana pola automatycznie odświeża UI |
| Brak wbudowanej konwencji `ValueChanged` | `Value` + `ValueChanged` umożliwia `@bind-Value` |

## 5. Wiązanie danych

W Web Forms dane trzeba przypisać do `DataSource` i wywołać `DataBind()`, a pola idą przez `Eval` albo `BoundField`. W Blazor znacznik czyta właściwości bezpośrednio, a `@bind` / `@bind-Value` wiąże wartość dwukierunkowo bez postbacku.

| WebForms | Blazor |
| --- | --- |
| `DataSource` i `DataBind()` | Kolekcja w `@code` i pętla `@foreach` |
| `<%# Eval("Name") %>` | `@product.Name` |
| `asp:BoundField DataField="Name"` | `PropertyColumn Property="p => p.Name"` |
| `asp:TextBox` odczytuje `Text` po postbacku | `@bind` aktualizuje pole na bieżąco |
| Dwukierunkowe wiązanie wymaga zdarzenia i code-behind | `@bind-Value` korzysta z `Value` + `ValueChanged` |
| Zmiana źródła wymaga ponownego `DataBind()` | Zmiana pola automatycznie odświeża UI |

## 6. Listy

W Web Forms listę buduje `Repeater`: źródło idzie do `DataSource`, a elementy powstają po `DataBind()` z szablonów. W Blazor lista to kolekcja w `@code` i zwykła pętla `@foreach`.

| WebForms | Blazor |
| --- | --- |
| `asp:Repeater` z `ItemTemplate` | Pętla `@foreach` |
| `<%# Eval("Name") %>` | `@product.Name` |
| Wymaga `DataSource` i `DataBind()` | Wystarczy kolekcja w `@code` |
| Pusta lista nic nie renderuje, chyba że obsłużysz to w code-behind | Pusty stan to zwykły `@if` |
| Zmiana listy wymaga ponownego `DataBind()` | Zmiana kolekcji odświeża listę automatycznie |

## 7. Nawigacja

W Web Forms link prowadzi do pliku `.aspx` albo przyjaznego adresu z FriendlyUrls, a kod zmienia stronę przez `Response.Redirect`. W Blazor `Router` wybiera komponent po trasie z `@page`, menu używa `NavLink`, a kod nawiguje przez `NavigationManager.NavigateTo`.

| WebForms | Blazor |
| --- | --- |
| `href="~/About"` albo `About.aspx` | `NavLink href="about"` albo `href="about"` |
| Adres wynika z pliku albo FriendlyUrls | Adres wynika z dyrektywy `@page` |
| `Response.Redirect` i `Server.Transfer` | `NavigationManager.NavigateTo` |
| `HyperLink` i zwykły znacznik `a` | `NavLink` zaznacza aktywną trasę |
| Każde przejście ładuje nową stronę | Router podmienia komponent bez przeładowania dokumentu |
| Query string i `Request.QueryString` | Parametry trasy w `@page` i `NavigationManager.Uri` |

Ten sam rekord w katalogu produktów pokazuje różnicę najczytelniej: Web Forms dokłada `id` w query string strony `.aspx`, a Blazor wstawia go w trasę komponentu.

- Web Forms: `Training.WebForms/ProductDetails.aspx`, `ProductDetails.aspx.cs`
- Blazor: `Training.Blazor/Components/Pages/ProductDetails.razor`

| Web Forms | Blazor |
| --- | --- |
| `ProductDetails.aspx?id=15` | `/products/15` |
| osobna strona `.aspx` | komponent `.razor` |
| `Request.QueryString["id"]` | `[Parameter] public int Id` |
| ręczne `int.Parse()` | `{Id:int}` + binding parametru |
| `NameLabel.Text = ...` | `@product.Name` |
| kontrolki serwerowe | HTML + Razor |

## 8. Tabele

W Web Forms tabelę danych daje `GridView`: kolumny ustawia `BoundField`, a wiersze powstają po `DataBind()`. W Blazor `QuickGrid` dostaje kolekcję `IQueryable`, a kolumny opisuje `PropertyColumn` z lambdą do właściwości.

| WebForms | Blazor |
| --- | --- |
| `asp:GridView` | `QuickGrid` |
| `BoundField DataField="Name"` | `PropertyColumn Property="p => p.Name"` |
| `DataFormatString="{0:C}"` | `Format="C"` |
| `EmptyDataText="No products"` | Własny `@if` nad pustą kolekcją |
| Sortowanie i paging to atrybuty kontrolki | `Sortable="true"` na kolumnie `QuickGrid` |
| Wymaga `DataSource` i `DataBind()` | Wystarczy `Items="@products"` |
| `AutoGenerateColumns` buduje kolumny ze schematu | Kolumny trzeba zadeklarować |

## 9. Szablony

W Web Forms szablon to `ITemplate` wewnątrz kontrolki: `HeaderTemplate`, `ItemTemplate` i `FooterTemplate` opisują znaczniki, a dane wchodzą przez `Eval`. W Blazor szablon to `RenderFragment` albo zwykły znacznik w komponencie — dziecko przekazuje markup jako `ChildContent`.

| WebForms | Blazor |
| --- | --- |
| `HeaderTemplate`, `ItemTemplate`, `FooterTemplate` | Markup wokół pętli `@foreach` |
| `<%# Eval("Name") %>` w szablonie | `@product.Name` w znaczniku |
| `ITemplate` i `TemplateField` | `RenderFragment` i `RenderFragment<T>` |
| Szablon jest właściwością kontrolki | Dziecko przekazuje `ChildContent` |
| Wiązanie w szablonie wymaga `DataBind()` | Szablon renderuje się razem z komponentem |
| AlternatingItemTemplate i SeparatorTemplate | Warunek `@if` albo własna logika w pętli |

## 10. Cykl życia

W Web Forms cykl życia dotyczy strony: każde żądanie tworzy nową instancję `Page` i przechodzi przez `Init`, `Load`, `PreRender` i `Unload`. W Blazor cykl życia należy do komponentu — instancja może żyć między zdarzeniami i woła `OnInitialized`, `OnParametersSet` oraz `OnAfterRender`.

| WebForms | Blazor |
| --- | --- |
| `Page_Init` / `OnInit` | `OnInitialized` / `OnInitializedAsync` |
| `Page_Load` / `OnLoad` | `OnParametersSet` / `OnParametersSetAsync` |
| `Page_PreRender` | `OnAfterRender` / `OnAfterRenderAsync` |
| `Page_Unload` | `IDisposable` / `Dispose` |
| `IsPostBack` rozróżnia pierwsze żądanie | `firstRender` w `OnAfterRender` |
| Cykl powtarza się przy każdym postbacku | Cykl instancji trwa między zdarzeniami |
| Kontrolka uczestniczy w cyklu strony | Komponent ma własny cykl życia |

## 11. Formularze

W Web Forms cała strona leży w jednym `form runat="server"`: kontrolki `TextBox` i walidatory biorą udział w postbacku. W Blazor formularz to `EditForm` związany z modelem — pola używają `@bind-Value`, a walidacja idzie przez adnotacje i `DataAnnotationsValidator`.

| WebForms | Blazor |
| --- | --- |
| Jeden `form runat="server"` na stronę | `EditForm` wokół modelu |
| `asp:TextBox`, `asp:DropDownList` | `InputText`, `InputSelect` |
| Wartość wraca w postbacku i ViewState | `@bind-Value` aktualizuje pole modelu |
| `RequiredFieldValidator`, `CompareValidator` | Atrybuty `[Required]`, `[Compare]` |
| `ValidationSummary` | `ValidationSummary` i `ValidationMessage` |
| Przycisk wysyła całą stronę | `OnValidSubmit` wywołuje metodę komponentu |
| `CausesValidation` steruje walidacją przy kliknięciu | Walidacja uruchamia się przy submitcie `EditForm` |

Nowy produkt pokazuje zmianę mentalną najczytelniej: Web Forms najpierw trzyma wartości w kontrolkach i dopiero przy zapisie składa `Product`. Blazor od początku ma `Product` i wiąże z nim pola.

- Web Forms: `Training.WebForms/ProductCreate.aspx`, `ProductCreate.aspx.cs`
- Blazor: `Training.Blazor/Components/Pages/ProductCreate.razor` (`/products/create`)

| Web Forms | Blazor |
| --- | --- |
| Kontrolki → odczyt wartości → `Product` → zapis | `Product` ↔ binding ↔ UI → zapis tego samego `Product` |
| `Name = NameTextBox.Text` | `<InputText @bind-Value="product.Name" />` |
| `decimal.Parse(PriceTextBox.Text)` | `<InputNumber @bind-Value="product.Price" />` |
| `if (!Page.IsValid) return;` | `OnValidSubmit="Save"` |
| walidator na `NameTextBox` | `[Required]` na `product.Name` |
| `Response.Redirect("Products.aspx")` | `Navigation.NavigateTo("/products")` |

## 12. Walidacja

W Web Forms walidacja siedzi przy kontrolce: `RequiredFieldValidator` wskazuje `ControlToValidate`, a po postbacku sprawdzasz `Page.IsValid`. W Blazor reguły należą do modelu — atrybuty `[Required]` i `[Range]` ocenia `DataAnnotationsValidator` w `EditForm`. Biblioteki FluentValidation i Blazor.FluentValidation pozwalają wynieść te reguły poza model, do osobnego walidatora.

| WebForms | Blazor |
| --- | --- |
| `RequiredFieldValidator`, `RangeValidator`, `RegularExpressionValidator` | `[Required]`, `[Range]`, `[RegularExpression]` |
| `ControlToValidate` wskazuje kontrolkę | Atrybut wisi na właściwości modelu |
| `Page.IsValid` po postbacku | `EditContext.Validate()` albo `OnValidSubmit` |
| `ValidationGroup` dzieli walidatory na grupy | Osobny `EditForm` albo własny `EditContext` |
| `CustomValidator` z metodą serwerową | Własny `ValidationAttribute` albo `IValidatableObject` |
| `ErrorMessage` na walidatorze | `ErrorMessage` w atrybucie albo `ValidationMessage` |
| Skrypt `WebUIValidation.js` waliduje po stronie klienta | `DataAnnotationsValidator` waliduje model w komponencie |
| Walidacja zostaje przy kontrolce albo w code-behind | FluentValidation i Blazor.FluentValidation wynoszą reguły poza model |

Ten sam formularz edycji produktu pokazuje różnicę najczytelniej: Web Forms wiesza walidator na kontrolce i sprawdza `Page.IsValid`, a Blazor wiąże `EditForm` z modelem i woła `OnValidSubmit` tylko gdy adnotacje przejdą.

- Web Forms: `Training.WebForms/ProductEditValidation.aspx`, `ProductEditValidation.aspx.cs`
- Blazor: `Training.Blazor/Components/Pages/ProductEditValidation.razor`

| Web Forms | Blazor |
| --- | --- |
| `TextBox` | `InputText` |
| `RequiredFieldValidator` | `[Required]` |
| `RangeValidator` | `[Range]` |
| `ValidationSummary` | `ValidationSummary` |
| walidator wskazuje `ControlToValidate` | komunikat wskazuje właściwość modelu |
| `Page.IsValid` | `OnValidSubmit` |
| dane odczytujemy z kontrolek | dane są związane z modelem |
| reguły często związane z UI | reguły mogą znajdować się w modelu |

Blazor nie zamyka walidacji na adnotacjach: te same reguły można wynieść do `AbstractValidator<T>` i podłączyć w `EditForm` przez FluentValidation. To trzecia droga obok kontrolek Web Forms i `[Required]` na modelu.

| Web Forms | DataAnnotations | FluentValidation |
| --- | --- | --- |
| reguła przy kontrolce | reguła przy modelu | reguła w osobnym validatorze |
| `RequiredFieldValidator` | `[Required]` | `.NotEmpty()` |
| `RangeValidator` | `[Range]` | `.GreaterThan()` / `.InclusiveBetween()` |
| mocno związane z UI | związane z klasą modelu | oddzielone od modelu |
| trudniejsze złożone reguły | ograniczone przy złożonych regułach | wygodne reguły warunkowe i złożone |

## 13. Layouty

W Web Forms szkielet strony to Master Page: plik `.Master` ma `ContentPlaceHolder`, a strona wstawia treść przez `asp:Content`. W Blazor layout dziedziczy po `LayoutComponentBase`, renderuje `@Body` i jest wybierany przez `DefaultLayout` albo dyrektywę `@layout`.

| WebForms | Blazor |
| --- | --- |
| Plik `.Master` | Komponent layoutu `.razor` |
| `MasterPageFile="~/Site.Master"` | `@layout MainLayout` albo `DefaultLayout` |
| `ContentPlaceHolder` | `@Body` |
| `asp:Content` wypełnia placeholder | Strona jest wstawiana w miejsce `@Body` |
| Master zawiera pełny dokument HTML | Dokument jest w `App.razor`, layout obejmuje treść |
| Zagnieżdżone Master Pages | Layout może mieć własny `@layout` |
| Strona bez mastera musi powtórzyć cały HTML | Strona bez layoutu renderuje sam komponent |

## 14. Ładowanie danych

W Web Forms dane ładujesz w `Page_Load`, zwykle tylko gdy `!IsPostBack`, potem ustawiasz `DataSource` i wołasz `DataBind()`. W Blazor dane pobierasz asynchronicznie w `OnInitializedAsync` — dopóki ich nie ma, znacznik pokazuje stan ładowania przez `@if`.

| WebForms | Blazor |
| --- | --- |
| `Page_Load` i `if (!IsPostBack)` | `OnInitializedAsync` |
| `DataSource` + `DataBind()` | Przypisanie kolekcji do pola komponentu |
| `SqlDataSource` / `ObjectDataSource` | Wstrzyknięty serwis albo `HttpClient` |
| Strona czeka, aż serwer skończy zapytanie | `await` i potem ponowny render |
| Brak wbudowanego stanu „ładowanie” | `@if (data == null)` pokazuje „Loading...” |
| Ponowne ładowanie wymaga postbacku albo `DataBind()` | Ponowne wywołanie metody odświeża UI |
| Cała odpowiedź HTML wraca na końcu | `[StreamRendering]` może wysłać najpierw szkielet |

Osobna strona `UiStateDemo` pokazuje różnicę między imperatywnym sterowaniem kontrolkami a deklaratywnym renderowaniem UI na podstawie stanu. Strony są niezależne od katalogu produktów. `GetAllAsync` ma krótkie opóźnienie, żeby grupa zdążyła zobaczyć ładowanie.

- Web Forms: `Training.WebForms/UiStateDemo.aspx`
- Blazor: `Training.Blazor/Components/Pages/UiStateDemo.razor` (`/ui-state-demo`)

Na tablicy:

Web Forms: zmień kontrolki → UI

Blazor: zmień stan → render → UI

W Web Forms code-behind mówi kontrolkom, co mają zrobić: `LoadingPanel.Visible = true`, `ProductsGrid.Visible = false`, `RefreshButton.Enabled = false`. W Blazorze zmieniasz stan (`isLoading = true`) i markup z niego wynika: `@if (isLoading)` oraz `disabled="@isLoading"`. Jedna zmienna może sterować kilkoma miejscami — nie trzeba osobno pamiętać o `Visible` i `Enabled`.

Empty: Web Forms ustawia `EmptyPanel.Visible = true`. Blazor nie mówi „pokaż EmptyPanel”, tylko „jeżeli kolekcja jest pusta, UI wygląda tak” (`@if (products is { Count: 0 })`).

Error: Web Forms w `catch` pokazuje `ErrorPanel`. Blazor zapisuje `error = ex.Message`, a markup decyduje `@if (error is not null)`. Na sali `ex.Message` jest tylko po to, żeby przykład był czytelny — w prawdziwej aplikacji nie pokazujemy użytkownikowi surowego komunikatu wyjątku.

Disabled przy zapisie to ten sam wzorzec: Web Forms `SaveButton.Enabled = false` i `SaveButton.Text = "Zapisywanie..."`. Blazor: `disabled="@isSaving"` i `@(isSaving ? "Zapisywanie..." : "Zapisz")`.

| Stan / zagadnienie      | Web Forms                                  | Blazor                                      |
| ----------------------- | ------------------------------------------ | ------------------------------------------- |
| **Loading**             | `LoadingPanel.Visible = true`              | `isLoading = true` + `@if (isLoading)`      |
| **Empty**               | Ustawienie `Visible` odpowiedniego `Panel` | Warunek `products.Count == 0` w markupie    |
| **Error**               | `ErrorPanel.Visible = true`                | `error = ...` + `@if (error != null)`       |
| **Disabled**            | `Button.Enabled = false`                   | `disabled="@isLoading"`                     |
| **Zmiana tekstu**       | `Button.Text = "Zapisywanie..."`           | `@(isSaving ? "Zapisywanie..." : "Zapisz")` |
| **Ukrywanie elementu**  | `Control.Visible = false`                  | Warunkowe renderowanie `@if (...)`          |
| **Gdzie sterujemy UI?** | Głównie w code-behind                      | Głównie deklaratywnie w `.razor`            |
| **Co przechowujemy?**   | Stan poszczególnych kontrolek              | Stan komponentu/aplikacji                   |
| **Sposób myślenia**     | „Ustaw właściwości kontrolek”              | „Zmień stan, a UI z niego wynika”           |

## 15. Usługi

W Web Forms strona zwykle sama tworzy zależności w code-behind albo sięga po `HttpContext` i `Global.asax`. W Blazor usługi rejestrujesz w `Program.cs`, a komponent bierze je przez `@inject` albo konstruktor.

| WebForms | Blazor |
| --- | --- |
| Brak wbudowanego kontenera DI | Kontener w `builder.Services` |
| `new` w code-behind albo fabryka | `@inject IMyService Service` |
| Stan aplikacji w `Application` / `HttpContext` | `AddSingleton`, `AddScoped`, `AddTransient` |
| `Global.asax` składa zależności przy starcie | `Program.cs` rejestruje usługi |
| Żądanie HTTP jest granicą życia obiektu | W Interactive Server `Scoped` żyje z obwodem SignalR |
| Biblioteki typu Unity albo Autofac są opcjonalne | DI jest częścią platformy |

## 16. Dependency Injection

W Web Forms platforma sama tworzy stronę, więc konstruktor rzadko dostaje zależności — trzeba dokładać kontener albo wołać `new`. W Blazor DI jest wbudowane: rejestracja w `IServiceCollection`, wstrzyknięcie przez `@inject`, `[Inject]` albo konstruktor.

| WebForms | Blazor |
| --- | --- |
| Strona powstaje przez framework, nie przez kontener | Komponent dostaje zależności z `IServiceProvider` |
| Wstrzyknięcie konstruktorem jest niewygodne | `@inject`, `[Inject]` albo konstruktor |
| Kontener (Unity, Autofac) trzeba podłączyć ręcznie | `builder.Services` jest gotowy od startu |
| Żądanie HTTP = typowy zakres | `Transient` / `Scoped` / `Singleton` |
| `HttpContext` zastępuje często usługę | Usługi frameworka (`NavigationManager`, `IJSRuntime`) też idą przez DI |
| Brak wbudowanego zakresu na kontrolkę | `OwningComponentBase` daje własny zakres na komponent |

## 17. Programowanie asynchroniczne

W Web Forms asynchroniczność trzeba włączyć na stronie (`Async="true"`) i zgłosić zadanie przez `RegisterAsyncTask` — zwykły `async void Page_Load` łatwo psuje cykl żądania. W Blazor metody cyklu życia i zdarzenia mogą zwracać `Task`, a po `await` komponent sam się odświeża.

| WebForms | Blazor |
| --- | --- |
| `<%@ Page Async="true" %>` | Asynchroniczność jest domyślnie dostępna |
| `RegisterAsyncTask` / `PageAsyncTask` | `OnInitializedAsync`, `OnParametersSetAsync` |
| `async void` w `Page_Load` jest ryzykowne | `async Task` w cyklu życia i w `@onclick` |
| Żądanie czeka na koniec, potem oddaje cały HTML | Po `await` Blazor renderuje ponownie |
| `HttpContext` po `await` bywa niedostępny | Stan zostaje w instancji komponentu |
| Event handler zostaje przy `void` i `EventArgs` | `EventCallback` może zwrócić `Task` |
| `SynchronizationContext` strony jest kruchy | Interactive Server utrzymuje kontekst obwodu |

## 18. Częściowe aktualizacje interfejsu

W Web Forms częściowy odśwież to `UpdatePanel` i `ScriptManager`: nadal jest postback, tylko odpowiedź HTML dotyczy panelu. W Blazor Interactive Server zmiana pola samo liczy różnicę drzewa renderowania i wysyła ją przez SignalR — bez `UpdatePanel`.

| WebForms | Blazor |
| --- | --- |
| `UpdatePanel` i `ScriptManager` | Różnica drzewa renderowania |
| Nadal HTTP POST (async postback) | Zdarzenie idzie przez SignalR |
| Serwer odsyła HTML fragmentu panelu | Blazor odsyła tylko zmiany UI |
| `AsyncPostBackTrigger` wskazuje, co odświeża panel | Zmiana stanu odświeża powiązany markup |
| `UpdateProgress` pokazuje oczekiwanie | Własny `@if` albo wskaźnik w komponencie |
| Poza panelem strona się nie zmienia, ale cykl strony i tak leci | `ShouldRender` / `StateHasChanged` sterują przerysowaniem |
| Bez `UpdatePanel` wraca cała strona | Częściowy update jest domyślny |

## 19. JavaScript

W Web Forms skrypty dokładasz przez `ScriptManager` i `ClientScript`, a kliknięcia często wołają JS obok postbacku. W Blazor logika zostaje w C# — do JS schodzisz świadomie przez `IJSRuntime` albo izolowany moduł `.razor.js`.

| WebForms | Blazor |
| --- | --- |
| `ScriptManager` i `ClientScript.RegisterStartupScript` | `IJSRuntime.InvokeAsync` |
| `ScriptBundle` w `BundleConfig` | Plik `.razor.js` albo skrypt w `wwwroot` |
| `onclick` i jQuery przy kontrolce | `@onclick` wywołuje metodę C# |
| JS i postback żyją obok siebie | JS interop jest jawnym mostem |
| `Page.ClientScript` wstrzykuje skrypt do odpowiedzi | `IJSObjectReference` trzyma uchwyt do modułu |
| Swobodna zmiana DOM | Nie ruszaj DOM-u, który renderuje Blazor |
| `Sys.Application` i `PageRequestManager` | `JSImport` / `JSExport` albo `ElementReference` |

Rozmiar okna jest lepszym przykładem niż `alert()`: C# na serwerze nie zna `window.innerWidth`. Strony są niezależne od katalogu produktów.

- Web Forms: `Training.WebForms/JavaScriptDemo.aspx` — `OnClientClick="showWindowSize(); return false;"` (bez postbacku)
- Blazor: `Training.Blazor/Components/Pages/JavaScriptDemo.razor` (`/javascript-demo`), `wwwroot/js/demo.js`

| Web Forms + JS | Blazor Interactive Server + JS interop |
| --- | --- |
| JS pobiera `window.innerWidth` | JS zwraca `{ width, height }` |
| JS sam ustawia `innerText` | C# ustawia `windowSize`, Blazor renderuje znacznik |
| klik → JS → Browser API → DOM | C# → `IJSRuntime` → JS → Browser API → wynik → C# → render |
| serwer nie wie o kliknięciu | klik idzie do C#, JS jest mostem do API przeglądarki |
| `return false` blokuje PostBack | `@onclick` zostaje w komponencie |

W Blazorze nie używamy JavaScriptu do ręcznego DOM-u, jeśli może to zrobić system renderowania. JS zostawiamy na API przeglądarki i biblioteki JS.

## 20. Sesja

W Web Forms `Session["klucz"]` żyje między postbackami i jest wiązany ciasteczkiem sesji. W Blazor Interactive Server stan i tak zostaje w instancji oraz w usługach `Scoped` na obwodzie SignalR — klasyczna `HttpContext.Session` działa głównie przy pierwszym żądaniu HTTP.

| WebForms | Blazor |
| --- | --- |
| `Session["UserId"]` | Pole komponentu albo usługa `Scoped` |
| Ciasteczko sesji i `Session_Start` | Obwód SignalR trzyma stan interakcji |
| InProc / StateServer / SQLServer | `ProtectedSessionStorage` / `ProtectedLocalStorage` |
| Sesja jest dostępna w każdym postbacku | `HttpContext.Session` nie jest dostępna po starcie obwodu |
| Stan poza stroną ląduje w sesji | Stan zostaje w komponencie albo w DI |
| Utrata sesji czyści dane użytkownika | Zerwanie obwodu gubi stan w pamięci serwera |

Dwa ekrany pokazują, po co w ogóle sesja: ustawienie na `PriceList` ma przeżyć przejście z powrotem na listę produktów. W Web Forms odpowiedzią jest `Session["MaxPrice"]`. W Blazor Interactive Server **nie kopiuj tego 1:1 do `HttpContext.Session`** — stan użytkownika wieszasz na usłudze `Scoped`, bo żyje z obwodem SignalR, a nie z ciasteczkiem sesji IIS.

Scenariusz: `Products` → `PriceList` (max 500) → `Products` pokazuje tylko tańsze pozycje. Pytanie do grupy: skąd lista zna wartość z innej strony?

- Web Forms: `Training.WebForms/PriceList.aspx`, `Products.aspx.cs`
- Blazor: `Training.Blazor/UserSession.cs`, `Components/Pages/PriceList.razor`, `Products.razor`

| Web Forms | Blazor Interactive Server |
| --- | --- |
| `PriceList.aspx` | `PriceList.razor` |
| `Products.aspx` | `Products.razor` |
| `Session["MaxPrice"]` | `UserSession.MaxPrice` |
| `HttpContext.Session` | serwis `Scoped` |
| rzutowanie `decimal?` | właściwość jest typowana |
| `Response.Redirect(...)` | `Navigation.NavigateTo(...)` |
| nowa instancja Page przy requestach | żyjące komponenty/circuit |
| stan sesji HTTP | stan w obiekcie C# circuitu |

`AddSingleton<UserSession>()` wyciekłoby `MaxPrice` między użytkownikami. F5 albo nowa karta w Blazorze to nowy obwód — stan znika, w Web Forms ta sama sesja HTTP zwykle zostaje.

Gdy stan ma przeżyć odświeżenie strony, Blazor ma coś, czego Web Forms nie mapuje 1:1: `ProtectedSessionStorage`. Zapisuje wartość w `sessionStorage` przeglądarki (zaszyfrowaną), a nie w `HttpContext.Session`. Odczyt jest po pierwszym renderze, bo to JS interop — stąd `OnAfterRenderAsync`.

- Blazor: `Training.Blazor/Components/Pages/UserPreferences.razor` (`/preferences`)

| Web Forms | Blazor `ProtectedSessionStorage` |
| --- | --- |
| `Session["x"]` | `ProtectedSessionStorage` |
| dane na **serwerze** | dane w **przeglądarce** |
| identyfikator sesji w cookie | dane w `sessionStorage` |
| dostęp przez `HttpContext.Session` | dostęp przez API browser storage |
| przetrwa kolejne requesty | przetrwa F5 |
| zwykle wspólne dla kart tej samej sesji HTTP | `sessionStorage` jest zasadniczo per karta |

## 21. Konfiguracja

W Web Forms konfiguracja siedzi w `Web.config`: `appSettings`, `connectionStrings` i transformacje `Web.Release.config`. W Blazor odczytujesz `IConfiguration` z `appsettings.json` i wariantów środowiska, a sekcje mapujesz na opcje przez `IOptions<T>`.

| WebForms | Blazor |
| --- | --- |
| `Web.config` (XML) | `appsettings.json` |
| `ConfigurationManager.AppSettings` | `IConfiguration["Klucz"]` |
| `connectionStrings` | Sekcja w JSON albo User Secrets |
| `Web.Debug.config` / `Web.Release.config` | `appsettings.Development.json` i zmienne środowiska |
| Zmiana często wymaga recykling puli IIS | Konfiguracja może być przeładowywana |
| Brak wbudowanego wzorca Options | `builder.Services.Configure<T>` i `IOptions<T>` |
| `system.web` steruje kompilacją i runtime | `Program.cs` składa hosta i usługi |

## 22. Uruchamianie aplikacji

W Web Forms aplikację hostuje IIS albo IIS Express: start to `Application_Start` w `Global.asax`, a pipeline składa `Web.config`. W Blazor hostem jest Kestrel — `Program.cs` buduje usługi, mapuje komponenty i woła `app.Run()`.

| WebForms | Blazor |
| --- | --- |
| IIS / IIS Express | Kestrel, ewentualnie za IIS albo nginx |
| `Global.asax` i `Application_Start` | `Program.cs` i `WebApplication.CreateBuilder` |
| `HttpApplication` i moduły `system.web` | Middleware w `app.Use...` |
| Projekt biblioteki hostowanej przez IIS | `dotnet run` albo profil z `launchSettings.json` |
| `RouteConfig` i `BundleConfig` przy starcie | `MapRazorComponents<App>()` przy starcie |
| Recykling puli aplikacji restartuje proces | Zatrzymanie procesu Kestrel restartuje aplikację |
| Brak własnego `Main` | Jawny `app.Run()` kończy składanie hosta |

## 23. Pipeline żądania

W Web Forms żądanie idzie przez IIS, `HttpModule` i `HttpHandler`, a zdarzenia aplikacji (`BeginRequest`, `AuthenticateRequest`) siedzą w `Global.asax`. W Blazor pipeline to łańcuch middleware w `Program.cs` — kolejność `app.Use...` decyduje, co dzieje się z żądaniem.

| WebForms | Blazor |
| --- | --- |
| `HttpModule` i `HttpHandler` | Middleware `app.Use...` |
| Zdarzenia `HttpApplication` w `Global.asax` | Jawna kolejność w `Program.cs` |
| `web.config` / `system.webServer` składa pipeline | Kod C# składa pipeline |
| Handler mapowany na rozszerzenie `.aspx` | `MapRazorComponents` obsługuje trasy |
| `BeginRequest` / `EndRequest` | Pierwszy i ostatni middleware |
| Trudniej wstawić własny krok pośrodku | Własny middleware to zwykła klasa albo lambda |

## 24. Uwierzytelnianie

W Web Forms typowy model to Forms Authentication: ciasteczko, `web.config` i `Membership` albo własny login. W Blazor dokładasz `AddAuthentication`, a stan użytkownika schodzi do komponentów przez `CascadingAuthenticationState` i `AuthenticationStateProvider`.

| WebForms | Blazor |
| --- | --- |
| `<authentication mode="Forms">` | `AddAuthentication()` w `Program.cs` |
| `FormsAuthentication.SetAuthCookie` | Cookie, OIDC albo Azure AD |
| `Membership` / `SimpleMembership` | ASP.NET Core Identity albo zewnętrzny IdP |
| `HttpContext.User` po module Forms | `AuthenticationState` i `ClaimsPrincipal` |
| Login to osobna strona `.aspx` | Strona `.razor` albo zdalny provider |
| Ciasteczko `.ASPXAUTH` | Ciasteczko schematu Cookie / OIDC |

## 25. Autoryzacja

W Web Forms dostęp tniesz w `web.config` (`<authorization>`, `<location>`) albo sprawdzasz role w code-behind. W Blazor używasz `[Authorize]`, `AuthorizeRouteView` i `AuthorizeView`, a reguły składasz w polityki.

| WebForms | Blazor |
| --- | --- |
| `<authorization>` i `<location path="Admin">` | `[Authorize]` na komponencie albo `AuthorizeRouteView` |
| `User.IsInRole("Admin")` w code-behind | `AuthorizeView Roles="Admin"` |
| `PrincipalPermission` albo własny `if` | Polityki `AddAuthorization` / `AddPolicy` |
| Odmowa to często redirect do logowania | `AuthorizeView` pokazuje `NotAuthorized` |
| Role z `roleManager` albo `web.config` | Role i claims z `ClaimsPrincipal` |
| Autoryzacja przy każdym nowym żądaniu | Sprawdzenie przy nawigacji i renderze komponentu |

## 26. Obsługa błędów

W Web Forms wyjątek łapie `customErrors` albo `Application_Error` i pokazuje Yellow Screen of Death. W Blazor pipeline kieruje na `/Error` przez `UseExceptionHandler`, a w UI możesz otoczyć drzewo `ErrorBoundary`.

Porównanie na żywo: `WebFormsApp/ErrorDemo.aspx` (PostBack → `Page_Error` → `Error.aspx`) oraz w Blazorze `/error-demo` (`ErrorBoundary` wokół `ErrorComponent`).

| Web Forms | Blazor |
| --- | --- |
| `Page_Error` | `ErrorBoundary` |
| granica związana ze stroną/requestem | granica w drzewie komponentów |
| błąd podczas PostBack | błąd komponentu interaktywnego |
| `Response.Redirect` | `ErrorContent` |
| przejście na `Error.aspx` | zastąpienie fragmentu UI |
| kolejny request tworzy stronę ponownie | komponenty działają w ramach circuitu |

| WebForms | Blazor |
| --- | --- |
| `customErrors` w `Web.config` | `app.UseExceptionHandler("/Error")` |
| `Application_Error` w `Global.asax` | Middleware wyjątków i `ILogger` |
| Yellow Screen of Death | Strona `Error.razor` |
| `Page_Error` na pojedynczej stronie | `ErrorBoundary` wokół fragmentu UI |
| `httpErrors` w IIS | `UseStatusCodePagesWithReExecute` |
| Szczegóły błędu zależą od `customErrors mode` | Szczegóły zależą od środowiska Development |

## 27. Logowanie

W Web Forms logi to zwykle `System.Diagnostics.Trace`, Event Log albo biblioteka typu log4net dokładana ręcznie. W Blazor `ILogger<T>` jest wbudowany — poziom ustawiasz w `appsettings.json`, a providerów dokładasz w `Program.cs`.

| WebForms | Blazor |
| --- | --- |
| `Trace.Write` / `Debug.WriteLine` | `ILogger<T>.LogInformation` |
| Event Log i `<healthMonitoring>` | Konsola, EventSource, Application Insights |
| log4net / NLog dokładane osobno | Provider NLog / Serilog podłączany do `ILogger` |
| Konfiguracja w `Web.config` | Sekcja `Logging` w `appsettings.json` |
| Brak wbudowanego kategorii/poziomów jak w Core | Kategorie i `LogLevel` per namespace |
| Logujesz w code-behind ad hoc | Wstrzykujesz `ILogger<T>` do komponentu albo usługi |

## 28. Dostęp do danych

W Web Forms dane idą często przez `SqlConnection`, `SqlDataSource` albo EF6 tworzone w code-behind. W Blazor `DbContext` i repozytoria wstrzykujesz z DI, a zapytanie wołasz w `OnInitializedAsync`.

| WebForms | Blazor |
| --- | --- |
| `SqlConnection` / `SqlCommand` w code-behind | EF Core, Dapper albo `HttpClient` |
| `SqlDataSource` i `ObjectDataSource` | Usługa zarejestrowana w DI |
| EF6 i `using (var db = new AppContext())` | `AddDbContext` i wstrzyknięty `DbContext` |
| Connection string w `Web.config` | Connection string w `appsettings.json` |
| `DataBind()` po pobraniu danych | Przypisanie wyniku do pola komponentu |
| Kontekst często związany z żądaniem strony | `DbContext` w zakresie `Scoped` (uwaga na obwód) |

## 29. API

W Web Forms API to zwykle `WebMethod` na stronie, serwis ASMX albo osobny projekt Web API. W Blazor backend to ten sam host: minimal API albo kontrolery, a komponent woła je przez `HttpClient` — albo pomija HTTP i używa wstrzykniętej usługi.

| WebForms | Blazor |
| --- | --- |
| `[WebMethod]` i ASMX | Minimal API albo `MapControllers` |
| Osobny projekt Web API | Endpointy w tym samym `Program.cs` |
| AJAX i `PageMethods` z aspx | `HttpClient` albo bezpośrednie wywołanie usługi |
| WSDL i SOAP obok REST | JSON i endpointy HTTP |
| Adres wynika z pliku `.asmx` | Adres mapujesz w `app.MapGet` / `MapPost` |
| Front i API często dwa pipeline | Jeden host może serwować UI i API |

## 30. SignalR

W Web Forms SignalR jest osobną biblioteką: hub, skrypt `jquery.signalR` i połączenie dokładane do strony. W Blazor Interactive Server SignalR jest transportem UI — kliknięcia i różnice renderu idą obwodem, a własny hub dokładasz tylko gdy potrzebujesz osobnego kanału.

| WebForms | Blazor |
| --- | --- |
| Pakiet `Microsoft.AspNet.SignalR` | SignalR wbudowany w Interactive Server |
| Hub i `/signalr/hubs` | Obwód (circuit) komponentu |
| Klient jQuery `$.connection` | Runtime Blazor utrzymuje połączenie |
| Strona działa też bez SignalR (postback) | Bez połączenia UI przestaje reagować |
| Własny hub do powiadomień i czatu | Ten sam hub możesz dodać obok obwodu |
| Ponowne połączenie piszesz sam | `ReconnectModal` i wbudowane ponawianie obwodu |
| Skalowanie hubów przez backplane | Skalowanie obwodów wymaga sticky session albo Azure SignalR |

## 31. WebAssembly

W Web Forms cały kod strony zawsze wykonuje się na serwerze — przeglądarka dostaje HTML. W Blazor ten sam komponent `.razor` może działać w przeglądarce: runtime .NET schodzi jako WebAssembly, a zdarzenia nie potrzebują SignalR.

| WebForms | Blazor |
| --- | --- |
| Brak modelu WASM | `@rendermode InteractiveWebAssembly` |
| Logika C# zostaje na serwerze | Logika C# może działać w przeglądarce |
| Przeglądarka dostaje HTML i JS | Przeglądarka pobiera runtime .NET i DLL |
| Każde kliknięcie idzie na serwer | Po załadowaniu UI działa lokalnie |
| Brak odpowiednika `Blazor WebAssembly` | Hosted WASM albo standalone `dotnet publish` |
| Stan i sekrety zostają na serwerze | Kod i stan klienta są widoczne w przeglądarce |
| Ciężar jest na IIS | Ciężar startu to pobranie WASM, potem mniej serwera |

## 32. Przechowywanie stanu w przeglądarce

W Web Forms przeglądarka trzyma głównie ciasteczka, ukryte pola i `__VIEWSTATE`. W Blazor stan UI zostaje w komponencie, a do przeglądarki sięgasz przez `ProtectedLocalStorage`, `ProtectedSessionStorage` albo JS `localStorage` / `sessionStorage`.

| WebForms | Blazor |
| --- | --- |
| `__VIEWSTATE` w ukrytym polu | Stan w instancji komponentu |
| `Session` i ciasteczko sesji | `ProtectedSessionStorage` |
| Ciasteczka `Response.Cookies` | Ciasteczko HTTP albo JS `document.cookie` |
| Brak wbudowanego `localStorage` | `ProtectedLocalStorage` / `IJSRuntime` |
| Dane wracają z każdym postbackiem | Zapisujesz świadomie, gdy potrzebujesz przetrwania |
| ViewState puchnie przy dużej stronie | Przechowujesz tylko to, co wybierzesz |

## 33. Testowanie

W Web Forms stronę trudno testować w izolacji — często zostaje Selenium albo test ręczny, bo `Page` i `HttpContext` są związane z IIS. W Blazor komponent testujesz bUnit, a przepływ w przeglądarce Playwright albo Selenium.

| WebForms | Blazor |
| --- | --- |
| `Page` wymaga kontekstu ASP.NET | bUnit renderuje komponent w pamięci |
| `HttpContext` trzeba podmieniać | Serwisy podstawiasz w DI testu |
| Test UI to głównie Selenium | Playwright, Selenium albo bUnit |
| Code-behind miesza UI i logikę | Logikę łatwiej wyciągnąć do usługi |
| Mało wbudowanych narzędzi | `bunit` jest typowym stackiem Blazor |
| Postback utrudnia asercje stanu | Stan odczytujesz z instancji komponentu |

## 34. Publikowanie

W Web Forms publikujesz na IIS przez Web Deploy albo folder: `Web.config`, bin i pliki `.aspx`. W Blazor wołasz `dotnet publish` — wychodzi samodzielna aplikacja Kestrel, katalog plików albo obraz kontenera.

| WebForms | Blazor |
| --- | --- |
| Web Deploy / Publish Web | `dotnet publish` |
| Profil `.pubxml` i transformacja `Web.config` | `appsettings` środowiska i zmienne |
| Precompilation `.aspx` jest opcjonalna | Kompilacja do DLL jest domyślna |
| Wynik to katalog strony IIS | Wynik to host + `wwwroot` |
| Zależność od IIS na maszynie docelowej | Możesz opublikować self-contained |
| `bin` + pliki strony | Folder publish albo obraz Docker |

## 35. Hosting

W Web Forms celem jest niemal zawsze Windows i IIS. W Blazor hostem jest Kestrel — za nim może stać IIS, nginx, Azure App Service albo kontener, a Blazor WebAssembly może iść na hosting statyczny.

| WebForms | Blazor |
| --- | --- |
| IIS / IIS Express na Windows | Kestrel na Windows, Linux i kontenerze |
| Pula aplikacji i `web.config` | Reverse proxy i zmienne środowiska |
| Azure Cloud Service / IIS na VM | App Service, Container Apps, AKS |
| Brak natywnego hostingu na Linux | Linux jest pierwszym klasycznym celem |
| Skalowanie puli IIS | Skalowanie procesu; Server wymaga sticky session |
| WASM nie istnieje | WASM można położyć na CDN / Static Web Apps |

## 36. Migracja aplikacji

Nie ma automatycznego konwertera `.aspx` na `.razor`. Migracja idzie ekran po ekranie: strona staje się komponentem, ViewState polem, User Control komponentem, a stary IIS i nowy host mogą chwilę żyć obok siebie.

| WebForms | Blazor |
| --- | --- |
| `.aspx` + code-behind | Jeden plik `.razor` |
| `Page_Load` i `IsPostBack` | `OnInitialized` / `OnParametersSet` |
| User Control `.ascx` | Komponent z `[Parameter]` |
| `Session` i ViewState | Pola, DI `Scoped`, storage w przeglądarce |
| `web.config` i Forms Auth | `appsettings` i ASP.NET Core Identity |
| Big-bang rewrite albo strangler | YARP / IIS jako fasada na czas migracji |
| Kontrolki serwerowe (`GridView`, `UpdatePanel`) | `QuickGrid`, `@bind`, własny markup |
