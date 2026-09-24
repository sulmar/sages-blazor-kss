using Microsoft.JSInterop;

namespace Training.Blazor.Services;

// Owija historię przeglądarki, żeby komponent nie wołał JS bezpośrednio.
public sealed class BrowserNavigation
{
    // Most do funkcji JavaScript.
    private readonly IJSRuntime _js;

    public BrowserNavigation(IJSRuntime js)
    {
        _js = js;
    }

    // Cofnięcie o jedną stronę w historii.
    public async Task GoBack()
    {
        // history.back() w przeglądarce, bez wartości zwrotnej.
        await _js.InvokeVoidAsync("history.back");
    }

    // Czy jest poprzednia strona, do której można wrócić.
    public async Task<bool> CanBack()
    {
        // history.length
        // var length = await _js.InvokeAsync<int>("history.length");
        // Długość historii z własnej funkcji JS.
        var length = await _js.InvokeAsync<int>("browserHistory.getLength");

        // Więcej niż bieżąca strona oznacza, że cofnięcie ma sens.
        return length > 1;
    }
}
