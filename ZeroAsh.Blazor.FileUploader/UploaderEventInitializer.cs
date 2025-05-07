using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ZeroAsh.Blazor.FileUploader;

public class UploaderEventInitializer(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./_content/ZeroAsh.Blazor.FileUploader/initializeUploaderEvents.js").AsTask());

    public async ValueTask<BindingReference> InitUploadArea(
        ElementReference containerElement,
        ElementReference uploadElement)
    {
        var module = await _moduleTask.Value;
        var disposable = await module.InvokeAsync<IJSObjectReference>(
            "initializeUploaderEvents",
            containerElement, uploadElement);
        
        return new BindingReference(disposable);
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        GC.SuppressFinalize(this);
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}