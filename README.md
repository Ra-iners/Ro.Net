# Ro.Net
An unofficial C# API for Roblox

Examples:

```csharp
using Ro.NET;
// Get Information about player
RobloxUser User = new RobloxUser("ROBLOX"); // can also be ID
Console.WriteLine($"Username        : {User.Username}");
Console.WriteLine($"User ID         : {User.Id}");
Console.WriteLine($"IsOnline        : {User.IsOnline}");
Console.WriteLine($"Headshot        : {User.Headshot}");
Console.WriteLine($"Avatar          : {User.Avatar}");
Console.WriteLine($"Bust            : {User.Bust}");
```
