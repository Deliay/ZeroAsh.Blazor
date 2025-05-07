ZeroAsh.Blazor
----
A various tools for my Blazor WASM applications

## Localization
Includes the `Microsoft.E.Localization` package and a basic localization switch component.

#### Install
``` bash
dotnet package add ZeroAsh.Blazor.Localization
```

#### Usage

```csharp
// Add localization services
builder.Services.AddZeroAshBlazorLocalization();

// Apply language settings
hist.Services.ApplyLanguageSettings();
```

And a simple language selector component was provided.
```html
IEnumerable<string> cultureNames = ["zh-CN", "en-US"];

var cultures = cultureNames.Select((name) => new CultureInfo(name));

<ZLanguageSelector SupportedCultures="@cultures" />
```

## File Upload
Include a upload event initializer and a simple component that support drag, paste, click to upload file.

#### Install
```bash
dotnet package add ZeroAsh.Blazor.FileUploader
```
#### Usage
Add initializer to dependency injection container
```csharp
builder.Service.AddFileUploaderInitializer();
```

Use the upload component
```html
<ZUpload OnChange="((InputFileChangeEventArgs e) => {...})">
    <p>Drag, paste, click to upload file</p>
</ZUpload>
```