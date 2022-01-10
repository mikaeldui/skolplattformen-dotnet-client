# Skolplattformen .NET Client
![Bygge av källkoden](https://github.com/mikaeldui/skolplattformen-dotnet-client/workflows/Bygge%20av%20k%C3%A4llkoden/badge.svg) [![NuGet version (MikaelDui.Skolplattformen.Client)](https://img.shields.io/nuget/v/MikaelDui.Skolplattformen.Client.svg?style=flat-square)](https://www.nuget.org/packages/MikaelDui.Skolplattformen.Client/) 

An unofficial .NET client for Skolplattformen. You could use it to create your very own Skolplattformen app with, for example, [Xamarin](https://dotnet.microsoft.com/apps/xamarin) and [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)!

Currently under development, everything hasn't been tested yet. Please [create an issue](https://github.com/mikaeldui/skolplattformen-dotnet-client/issues) if you encounter any problems.

## Installation 

You can install the [NuGet package](https://www.nuget.org/packages/MikaelDui.Skolplattformen.Client/) using the following command:

    dotnet add package MikaelDui.Skolplattformen.Client --version *

## Example

```C#
using (var client = new SkolplattformenVardnadshavareClient())
{
    // Login with BankID
    await client.TryAuthenticateAsync("121212-1212");

    // Get the current user
    var user = await client.GetUserAsync();

    // Get children
    var children = await client.GetChildrenAsync();

    // Get the news for the first child
    var news = await client.GetNewsAsync(children[0]);
}
```

## Related

If you want a JavaScript version, check out the project [kolplattformen/embedded-api](https://github.com/kolplattformen/embedded-api).
