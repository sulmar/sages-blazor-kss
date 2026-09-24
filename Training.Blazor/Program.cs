using Bogus;
using StackExchange.Redis;
using Training.Blazor.Abstractions;
using Training.Blazor.Components;
using Training.Blazor.Fakers;
using Training.Blazor.Models;
using Training.Blazor.Services;

// Buduje host aplikacji i kontener DI.
var builder = WebApplication.CreateBuilder(args);

// Rejestracja komponentów Razor.
builder.Services.AddRazorComponents()
    // Włącza interaktywny render po stronie serwera.
    .AddInteractiveServerComponents();

// Jedna instancja serwisu produktów na całą aplikację.
builder.Services.AddSingleton<IProductService, FakeProductService>();
// Generator danych testowych dla produktu.
builder.Services.AddSingleton<Faker<ProductListItem>, ProductFaker>();
// Nowa instancja nawigacji na każdy obieg Blazor.
builder.Services.AddScoped<BrowserNavigation>();

// Cache Redis — connection string z konfiguracji.
builder.Services.AddStackExchangeRedisCache(
    options => options.Configuration = builder.Configuration.GetConnectionString("Redis"));

// Złożenie potoku HTTP.
var app = builder.Build();

// Poza Development błędy idą na stronę /Error.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // HSTS wymusza HTTPS w przeglądarce.
    app.UseHsts();
}

// Przekierowanie HTTP na HTTPS.
app.UseHttpsRedirection();

// Pliki z wwwroot.
app.UseStaticFiles();
// Token antiforgery wymagany przez formularze Blazor.
app.UseAntiforgery();

// Mapuje komponent App jako korzeń UI.
app.MapRazorComponents<App>()
    // Udostępnia tryb InteractiveServer na endpointach.
    .AddInteractiveServerRenderMode();

// Start serwera.
app.Run();
