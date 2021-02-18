# Skolplattformen .NET Client
![Bygge av källkoden](https://github.com/mikaeldui/skolplattformen-dotnet-client/workflows/Bygge%20av%20k%C3%A4llkoden/badge.svg) [![NuGet version (MikaelDui.Skolplattformen.Client)](https://img.shields.io/nuget/v/MikaelDui.Skolplattformen.Client.svg?style=flat-square)](https://www.nuget.org/packages/MikaelDui.Skolplattformen.Client/) 

An unofficial .NET client for Skolplattformen. You could use it to create your own Skolplattformen app using e.g. [Xamarin](https://dotnet.microsoft.com/apps/xamarin) or [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)!

Currently under development, nothing has been tested yet.

You can install the latest prerelease using the following command:

    dotnet add package MikaelDui.Skolplattformen.Client --prerelease

## Example

```C#
using (var client = new SkolplattformenVardnadshavareClient())
{
    // Log in with BankID
    await client.TryAuthenticateAsync("121212-1212");

    // Get the current user
    var user = await client.GetUserAsync();

    // Get children
    var children = await client.GetChildrenAsync();

    // Get the news for the first child
    var news = await client.GetNewsAsync(children[0]);
}
```
