STAYBNB SOURCE PACK — merge into your local VS project
======================================================

This is NOT a full .sln (keeps size small). Copy files into:
  C:\Users\Shivaar\source\repos\Staybnb\

1. DELETE Data\ApplicationUser.cs if it exists (use Models\ApplicationUser.cs only)
2. Copy Models\*, Data\*, Controllers\*, Views\* over matching folders
3. Copy Program.cs, appsettings.json
4. Copy Areas\Identity\Pages\Account\Register.cshtml.cs
5. PMC:
     Install-Package Microsoft.AspNetCore.Identity.UI -Version 9.0.21
6. Clean + Rebuild
7. Update-Database if needed
8. F5 and follow SUBMISSION.md smoke test

SuperAdmin: superadmin@staybnb.local / SuperAdmin@123
