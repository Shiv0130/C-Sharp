# Staybnb — Lab 3 complete (roles + SuperAdmin + Guest on register)

Committed on branch **Assignment** under `Sem2/Staybnb/`.

## Files in this commit
- `Models/AppRoles.cs` — Guest, Host, Admin, SuperAdmin
- `Data/DbSeeder.cs` — seeds roles + SuperAdmin on startup
- `Program.cs` — ApplicationUser + roles + seeder call
- `Areas/Identity/Pages/Account/Register.cshtml.cs` — assigns Guest after CreateAsync

## How to use with your local Staybnb project

Your working app is likely at:
`C:\Users\Shivaar\source\repos\Staybnb`

**Option A — copy files into local project**
1. Copy `AppRoles.cs` → `Models/`
2. Copy `DbSeeder.cs` → `Data/`
3. Replace local `Program.cs` with this one
4. Replace local `Areas/Identity/Pages/Account/Register.cshtml.cs` with this one  
   (scaffold Register once first if the folder does not exist)
5. Build → F5

**Option B — pull Assignment branch**
```bash
git fetch origin
git checkout Assignment
# then copy Sem2/Staybnb/* into your VS Staybnb solution folders
```

## Test credentials
- SuperAdmin: `superadmin@staybnb.local` / `SuperAdmin@123`
- New Register user → must get **Guest** role

## Next: Lab 4
Host application form (property + at least one image, status Pending).
