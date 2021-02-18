# Skolplattformen .NET Client

![Bygge av källkoden](https://github.com/mikaeldui/skolplattformen-dotnet-client/workflows/Bygge%20av%20k%C3%A4llkoden/badge.svg)

An unofficial .NET client for Skolplattformen.

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
    var chidlren = await client.GetChildrenAsync();

    // Get the news for the first child
    var news = await client.GetNewsAsync(children[0]);
}
```
