using Microsoft.Extensions.DependencyInjection;

namespace ZeroAsh.Blazor.FileUploader;

public static class FileUploaderExtensions
{
    public static IServiceCollection AddFileUploaderInitializer(this IServiceCollection services)
    {
        services.AddSingleton<UploaderEventInitializer>();
        return services;
    }
}
