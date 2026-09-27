# C-Sharp

Semester 1 console work and Semester 2 ASP.NET Core MVC (Programming 742).

## .NET 8 / 9 / 10 switch (lab PC vs laptop vs Lunga zip)

Campus labs = **.NET 8**. Laptop VS 2022 here = **.NET 9**. Lunga sometimes sends zips from **VS 2026 / .NET 10**. Same C# code. Different `<TargetFramework>` and EF package majors. That mismatch is what kills `Add-Migration`.

**Close Visual Studio first. Then:**

| Machine | Double-click |
|---|---|
| Campus lab | `to-net8.bat` |
| Your laptop | `to-net9.bat` |
| Lunga demo PC | `to-net10.bat` |
| Lunga emailed a zip | Extract it, then run `ingest-lunga.bat` and paste the extracted folder |

`ingest-lunga.bat` copies the four scripts into the unzipped folder and retargets every `.csproj` it finds (default **net8** for the lab).

Do not commit a net10 flip after a lab session. Commit code, not the TFM bounce.

```
git checkout -- "*.csproj" global.json
```

Staybnb / Moodle submission should be **net8.0**.
