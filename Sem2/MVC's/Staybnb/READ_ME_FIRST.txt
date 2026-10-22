CRITICAL BEFORE OPENING VS
==========================
1. Close Visual Studio completely.
2. In File Explorer go to:
   C:\Users\Shivaar\source\repos\Staybnb
3. DELETE the entire folder contents OR the whole Staybnb folder.
4. Extract THIS zip so Staybnb.csproj is at:
   C:\Users\Shivaar\source\repos\Staybnb\Staybnb.csproj
5. If you still see Data\ApplicationUser.cs after extract — DELETE IT.
   (This zip does not include that file on purpose.)
6. Delete bin and obj if they reappear from old project.
7. Open Staybnb.csproj in VS → wait for NuGet restore → Rebuild.
8. Package Manager Console:
   Update-Database
9. F5

SuperAdmin login:
  superadmin@staybnb.local
  SuperAdmin@123

CS0104 ApplicationUser ambiguous = Data\ApplicationUser.cs still exists → delete it.
CS0234 UIFrameworkAttribute = Identity.UI package missing → this csproj already includes it;
  if error remains: delete bin+obj, Rebuild, or run:
  Install-Package Microsoft.AspNetCore.Identity.UI -Version 9.0.21
