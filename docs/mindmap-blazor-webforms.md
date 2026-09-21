# WebForms → Blazor

## Dzień 1 — model mentalny

### 1. Zmiana modelu
- Strony
  - `.aspx` → `.razor`
  - plik na dysku → `@page`
  - `Page` → `ComponentBase`
- Stan
  - ViewState → instancja komponentu
  - HTTP POST → SignalR
  - cała strona HTML → różnica UI
- Cykl życia
  - `Page_Load` / `IsPostBack`
  - `OnInitialized` / `OnParametersSet`
  - `OnAfterRender` / `IDisposable`
- Częściowe aktualizacje
  - `UpdatePanel` → render diff
  - `ScriptManager` → SignalR
- Przykład
  - Counter.aspx
  - Counter.razor

### 2. Pierwszy ekran
- Listy
  - Repeater → `@foreach`
  - `Eval` → `@product.Name`
- Tabele
  - GridView → QuickGrid / HTML
  - `DataSource` + `DataBind()`
- Ładowanie danych
  - `Page_Load` + `!IsPostBack`
  - `OnInitializedAsync`
- Usługi i DI
  - `new` w code-behind
  - `@inject` + `Program.cs`
- Async
  - `Async="true"` / `RegisterAsyncTask`
  - `async Task` w cyklu życia
- Dostęp do danych
  - `SqlDataSource` / EF6
  - EF Core / serwis z DI
- Przykład
  - Products.aspx
  - Products.razor

### 3. Nawigacja
- Routing
  - `About.aspx` → `@page "about"`
  - FriendlyUrls → Router
- Parametry
  - `QueryString["id"]` → `{Id:int}`
  - `int.Parse` → `[Parameter]`
- Przejścia
  - `Response.Redirect` → `NavigationManager`
  - `HyperLink` → `NavLink`
- Przykład
  - ProductDetails.aspx?id=15
  - /products/15

### 4. Edycja
- Wiązanie danych
  - `TextBox.Text` po postbacku
  - `@bind` / `@bind-Value`
- Zdarzenia
  - `OnClick` + postback
  - `@onclick` + SignalR
  - `EventHandler` → `EventCallback`
- Zapis i powrót
  - odczyt kontrolek → `Product`
  - ten sam model od początku
  - `NavigateTo("/products")`

### 5. Formularze
- EditForm
  - `form runat="server"` → `EditForm`
  - `TextBox` → `InputText`
- Walidacja
  - `RequiredFieldValidator`
  - `[Required]` / `[Range]`
  - `Page.IsValid` → `OnValidSubmit`
- Bonus
  - FluentValidation
  - reguły poza modelem
- Przykład
  - ProductCreate / ProductEdit

## Dzień 2 — katalog produktów

### 6. Komponentowość
- Komponenty
  - User Control `.ascx`
  - komponent `.razor`
  - `[Parameter]`
  - `EventCallback`
- Szablony
  - `ItemTemplate` / `Eval`
  - `RenderFragment` / `ChildContent`
- Layouty
  - Master Page → `MainLayout`
  - `ContentPlaceHolder` → `@Body`
- Plac zabaw
  - ProductForm
  - ComponentDemo

### 7. Dodawanie produktu
- Ten sam ProductForm
  - Create vs Edit
  - `SubmitText`
  - `OnValidSubmit`
- Strony
  - ProductCreateWithComponent
  - ProductEditWithComponent

### 8. Interaktywność
- Wyszukiwanie
- Filtrowanie
- Sortowanie
- QuickGrid
  - `PropertyColumn`
  - `Sortable`

### 9. Stan UI
- Loading
  - `Panel.Visible` → `@if (isLoading)`
- Empty
  - `EmptyPanel` → `Count == 0`
- Error
  - `ErrorPanel` → `@if (error != null)`
- Disabled przy zapisie
  - `Button.Enabled` → `disabled="@isSaving"`
- Myślenie
  - ustaw kontrolki
  - zmień stan, UI wynika
- Przykład
  - UiStateDemo

## Dzień 3 — architektura

### 10. Architektura aplikacji
- DI i lifetime
  - Transient / Scoped / Singleton
  - Scoped = obwód SignalR
  - logika poza `.razor`
- Sesja
  - `Session["klucz"]`
  - usługa Scoped
  - nie kopiować HttpContext.Session
- Storage w przeglądarce
  - ViewState / cookies
  - ProtectedSessionStorage
  - ProtectedLocalStorage
- Konfiguracja
  - Web.config → appsettings.json
  - `IOptions<T>`
- Host i pipeline
  - IIS + Global.asax
  - Kestrel + Program.cs
  - HttpModule → middleware
- Przykład
  - PriceList + UserSession
  - UserPreferences

### 11. JavaScript
- JS interop
  - ScriptManager → IJSRuntime
  - most do API przeglądarki
- Czego nie robić
  - nie ruszać DOM-u Blazora
  - nie budować UI „po javascriptowemu”
- Przykład
  - JavaScriptDemo
  - window.innerWidth

### 12. Server vs WASM
- Interactive Server
  - SignalR jako transport UI
  - stan na serwerze
- Interactive WebAssembly
  - C# w przeglądarce
  - ten sam komponent `.razor`
- Własny hub SignalR
  - tylko gdy potrzebny osobny kanał

## Dalsza droga

### Bezpieczeństwo
- Uwierzytelnianie
  - Forms Auth → Cookie / OIDC / Identity
  - CascadingAuthenticationState
- Autoryzacja
  - web.config `<authorization>`
  - `[Authorize]` / AuthorizeView

### Operacje
- Obsługa błędów
  - customErrors / YSOD
  - UseExceptionHandler / ErrorBoundary
- Logowanie
  - Trace / log4net
  - ILogger<T>
- API
  - WebMethod / ASMX
  - Minimal API / HttpClient
- Testowanie
  - Selenium / ręcznie
  - bUnit + Playwright
- Publikowanie
  - Web Deploy
  - `dotnet publish`
- Hosting
  - IIS / Windows
  - Kestrel / Linux / kontener / WASM na CDN

### Migracja
- Brak konwertera aspx → razor
- Ekran po ekranie
  - strona → komponent
  - ViewState → pole
  - User Control → komponent
- Strangler
  - YARP / IIS jako fasada
- Mapowanie kontrolek
  - GridView → QuickGrid
  - UpdatePanel → render diff
  - Session → Scoped / storage
