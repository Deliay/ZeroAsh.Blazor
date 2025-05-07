using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace ZeroAsh.Blazor.Localization;

public static class ZeroAshBlazorExtensions
{
    public static IServiceCollection AddZeroAshBlazorLocalization(this IServiceCollection services,
        Action<LocalizationOptions> options)
    {
        services.AddLocalization(options);
        services.AddScoped<LanguageSetterJsInterop>();

        return services;
    }

    public static async ValueTask ApplyLanguageSettings(this IServiceProvider services, string defaultCulture)
    {
        var js = services.GetRequiredService<LanguageSetterJsInterop>();
        var result = await js.GetLocalization();
        
        var culture = CultureInfo.GetCultureInfo(result ?? defaultCulture);

        if (result == null) await js.SetLocalization(defaultCulture);;

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}