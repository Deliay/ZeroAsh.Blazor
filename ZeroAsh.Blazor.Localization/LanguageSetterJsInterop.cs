using Microsoft.JSInterop;

namespace ZeroAsh.Blazor.Localization;

public class LanguageSetterJsInterop(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./_content/ZeroAsh.Blazor.Localization/languageSetter.js").AsTask());

    public async ValueTask SetLocalization(string localeCode)
    {
        var module = await moduleTask.Value;
        await module.InvokeAsync<string>("setLocalization", localeCode);
    }
    
    public async ValueTask<string?> GetLocalization()
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("getLocalization");
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}