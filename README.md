ZeroAsh.Blazor
----
A various tools for my Blazor WASM applications

## Localization
Inlucdes the `Microsoft.E.Localization` package and a basic localization switch component.

#### Install
```
dotnet package add ZeroAsh.Blazor.Localization
```

#### Usage

```csharp
// Add localization services
builder.Services.AddZeroAshBlazorLocalization();

// Apply language settings
hist.Services.ApplyLanguageSettings();

// Set language into browser local storage
var js = services.GetServiceRequired<LanguageSetterJsInterop>();
var culture = new CultureInfo("zh-CN");
await js.SetLocalization(culture.Name);
```

And a simple language selector component was provided.
```csharp
IEnumerable<string> cultureNames = ["zh-CN", "en-US"];
var cultures = cultureNames.Select((name) => new CultureInfo(name));

<LanguageSelector SupportedCultures="@cultures">
</LanguageSelector>
```