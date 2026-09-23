using Microsoft.JSInterop;

namespace Training.Blazor.Services;

public sealed class BrowserNavigation
{
    private readonly IJSRuntime _js;

    public BrowserNavigation(IJSRuntime js)
    {
        _js = js;
    }

    public async Task GoBack()
    {
        await _js.InvokeVoidAsync("history.back");
    }

    public async Task<bool> CanBack()
    {
        // histor.length
        // var length = await _js.InvokeAsync<int>("history.length");
        var length = await _js.InvokeAsync<int>("browserHistory.getLength");

        return length > 1;
    }

}
