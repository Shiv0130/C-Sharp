# Staybnb

ASP.NET Core MVC application for Programming 742. Guests browse and book stays. Guests can apply to become Hosts. Administrators approve applications and audit activity. SuperAdmin manages roles.

## Requirements

- Visual Studio 2022
- .NET 9 SDK
- SQL Server LocalDB

## Run

1. Open `Staybnb.csproj`.
2. Package Manager Console:

```
Update-Database
```

3. Press F5.
4. Seeding runs on startup.

## Demo accounts

| Role | Email | Password |
|------|--------|----------|
| SuperAdmin | superadmin@staybnb.local | SuperAdmin@123 |
| Host | host@staybnb.local | Host@123456 |
| Guest | guest@staybnb.local | Guest@123456 |

New registrations are always assigned the Guest role. Log out and log back in after a role change so the new role takes effect.

## Roles

- **Guest** — explore listings, book, apply to become a host, check in after approval.
- **Host** — manage properties, approve or reject bookings, verify check-in documents.
- **Admin** — review host applications, view activity logs.
- **SuperAdmin** — promote users, set roles, reset passwords.

## Main flows

1. Register → automatic Guest role.
2. Become a Host → property details plus at least one image → pending application.
3. SuperAdmin or Admin approves → Guest role removed, Host role added, property set active.
4. Guest books → total = (price per night × nights) + 250 cleaning fee + 150 service fee → status Pending.
5. Host approves booking → status Approved.
6. Guest uploads ID or passport → Host verifies → booking status CheckedIn.
7. Messages and notifications support read and unread.

## Structure

- `Controllers` — feature controllers
- `Models` — domain models
- `Data` — DbContext, seeder, migrations
- `Areas/Identity` — login and registration
- `Views` — Razor views
- `wwwroot/uploads` — property and document uploads

Seeding is programmatic in `Data/DbSeeder.cs`. No separate SQL script is required.
