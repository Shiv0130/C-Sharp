# Staybnb — submission checklist

## Copy from GitHub
Branch: **Assignment**  
Path: `Sem2/Staybnb/` → merge into local `C:\\Users\\Shivaar\\source\\repos\\Staybnb`

### Must copy
- Controllers/* (all)
- Views/** (all folders)
- Models/AppRoles.cs
- Data/DbSeeder.cs
- Program.cs
- Areas/Identity/Pages/Account/Register.cshtml.cs
- Views/Shared/_Layout.cshtml

Keep your existing Models (ApplicationUser, HostProperty, …) and ApplicationDbContext from Lab 2.

## After copy
1. Build solution (Ctrl+Shift+B)
2. Create folders if missing:
   - `wwwroot/uploads/properties`
   - `wwwroot/uploads/documents`
3. F5

## Full smoke test (do this before zip)
1. Login SuperAdmin: `superadmin@staybnb.local` / `SuperAdmin@123`
2. Register Guest A
3. Guest A → Become a Host (fill form + image)
4. SuperAdmin → Admin → Host requests → Approve  
   (Guest role removed, Host added, property active)
5. Logout → login as new Host → Host dashboard, toggle active
6. Register Guest B → Explore → View → Request booking
7. Host → Booking requests → Approve
8. Guest B → My bookings → Check-in → upload ID
9. Host → Check-in docs → Verify → booking status CheckedIn
10. Messages + Notifications pages open and mark read

## Zip for Moodle (≤50MB)
Exclude:
- `bin/`, `obj/`, `.vs/`, `node_modules/`
- large unused images

Include:
- full source
- PDF report (cover, intro, screenshots of flows, conclusion)
- this works offline with LocalDB after `Update-Database`

## Marks map
| Rubric | Covered by |
|--------|------------|
| Auth + Guest→Host | Register + Admin Approve |
| Admin dashboard | AdminController |
| Host application + image | HostApplicationsController |
| Booking Pending→Approved→CheckedIn | Bookings + CheckIn |
| Host dashboard | HostDashboardController |
| Messages & notifications | Messages + Notifications |
| Activity log | seeded on key actions |
| Data/migrations | Lab 2 |

Good luck — test the path above once, then zip.
