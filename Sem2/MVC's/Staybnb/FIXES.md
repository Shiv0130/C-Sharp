# Build fixes (do these on local Staybnb first)

## 1. Duplicate ApplicationUser (CS0104)

You have BOTH:
- `Data/ApplicationUser.cs`  (template default)
- `Models/ApplicationUser.cs` (Lab 2)

**Delete** `Data/ApplicationUser.cs` entirely.

Keep only **`Models/ApplicationUser.cs`**.

In `Data/ApplicationDbContext.cs` ensure:
```csharp
using Staybnb.Models;
// ...
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
```

Do **not** declare another ApplicationUser class in the Data namespace.

## 2. UIFrameworkAttribute (CS0234)

Package Manager Console:

```powershell
Install-Package Microsoft.AspNetCore.Identity.UI -Version 9.0.21
```

Then:

```powershell
dotnet clean
# or in VS: Build → Clean Solution, then Rebuild
```

If the error remains, close VS, delete folders `bin` and `obj`, reopen, Rebuild.

## 3. Pull latest controllers from this branch

All controllers now use only `Staybnb.Models.ApplicationUser`.

Copy from `Sem2/Staybnb/Controllers/*` again after the fixes above.
