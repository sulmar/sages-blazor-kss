using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Training.BlazorWasm;

// Host aplikacji działającej w przeglądarce.
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Komponent App wchodzi w element #app na stronie.
builder.RootComponents.Add<App>("#app");
// HeadOutlet renderuje tytuł strony w sekcji head.
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient ze bazowym adresem hosta — jedna instancja na obieg.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Start aplikacji w przeglądarce.
await builder.Build().RunAsync();
