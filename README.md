# Ro.Net
An unofficial C# API for Roblox

# Examples:
# Get information about user
```csharp
using Ro.NET;

RobloxUser User = new RobloxUser("ROBLOX"); // can also be ID
Console.WriteLine($"Username        : {User.Username}");
Console.WriteLine($"User ID         : {User.Id}");
Console.WriteLine($"IsOnline        : {User.IsOnline}");
Console.WriteLine($"Headshot        : {User.Headshot}");
Console.WriteLine($"Avatar          : {User.Avatar}");
Console.WriteLine($"Bust            : {User.Bust}");
```
# Get groups player is in
```csharp
using Ro.NET;

RobloxUser User = new RobloxUser("ROBLOX");
foreach (ulong GroupID in User.getUserGroups(User.Id))
{
    RobloxGroup Group = new RobloxGroup(GroupID);
    Console.WriteLine($"Group Name         : {Group.Name}");
    Console.WriteLine($"Group Description  : {Group.Description}");
    Console.WriteLine($"Group Owner        : {Group.OwnerUsername}");
    Console.WriteLine($"Group Owner ID     : {Group.OwnerId}");
    Console.WriteLine($"Emblem URL         : {Group.EmblemUrl}");
    Console.WriteLine($"Roles: ");
    foreach(var Role in Group.Roles)
    {
        Console.WriteLine($"{Role.Key} | {Role.Value}");
    }
    Console.WriteLine("\n");
    Group.Dispose();
}
User.Dispose();
```
