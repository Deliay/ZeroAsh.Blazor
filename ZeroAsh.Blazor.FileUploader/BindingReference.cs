using Microsoft.JSInterop;

namespace ZeroAsh.Blazor.FileUploader;

public readonly record struct BindingReference(IJSObjectReference Disposable) : IDisposable, IAsyncDisposable
{
    public async ValueTask DisposeAsync()
    {
        await Disposable.InvokeVoidAsync("dispose");
        await Disposable.DisposeAsync();
    }

    public void Dispose()
    {
        DisposeAsync().AsTask()
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();
    }
}
