# Staybnb progress (Assignment branch)

## Done on GitHub (copy into local VS project)

### Lab 1–2
- Identity project, ApplicationUser, domain models, DbContext relationships (you did locally)

### Lab 3
- `Models/AppRoles.cs`
- `Data/DbSeeder.cs` (roles + SuperAdmin)
- `Program.cs` (ApplicationUser + roles + seed)
- `Areas/Identity/Pages/Account/Register.cshtml.cs` (Guest on register)

### Lab 4 — Host application
- `Controllers/HostApplicationsController.cs`
- `Views/HostApplications/Create.cshtml`, `Status.cshtml`
- Requires `wwwroot/uploads/properties/` (created at runtime)

### Lab 5 — Admin approve + role swap
- `Controllers/AdminController.cs`
- Views: Index, Applications, ActivityLogs, Users
- Approve removes Guest, adds Host, activates property

### Lab 6 — Browse + book
- `Controllers/PropertiesController.cs`, `BookingsController.cs`
- Price: `(PricePerNight × Nights) + 250 + 150`
- Views for Index/Details/Create/MyBookings

### Lab 7 — Host dashboard + messages + notifications
- `Controllers/HostDashboardController.cs`
- `Controllers/MessagesController.cs`, `NotificationsController.cs`
- Matching views

## What YOU should finish (last stretch)
1. Copy all `Sem2/Staybnb` files into `C:\Users\Shivaar\source\repos\Staybnb`
2. Wire nav links in `_Layout.cshtml` (Guest / Host / Admin menus)
3. Create folder `wwwroot/uploads/properties`
4. F5 smoke test full flow:
   - Register Guest → Become a Host → SuperAdmin approves → Host sees dashboard → Guest books → Host approves booking
5. Optional thin extras: GuestDocument upload, CheckInProcess UI
6. Zip project ≤50MB (exclude bin/obj/.vs) + PDF report → Moodle

## Test accounts
- SuperAdmin: `superadmin@staybnb.local` / `SuperAdmin@123`
- Register other users as Guests

## Rubric coverage
| Area | Status |
|------|--------|
| Auth + Guest→Host swap | Controllers ready |
| Admin dashboard | Ready |
| Host application + image | Ready |
| Booking + price formula | Ready |
| Host approve booking | Ready |
| Messages + notifications | Ready |
| Activity log | Integrated on key actions |
| Check-in documents | Minimal / your optional last piece |
