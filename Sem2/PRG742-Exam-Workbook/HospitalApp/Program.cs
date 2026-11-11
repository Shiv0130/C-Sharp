// GIVEN FILE: you do not edit this one. It wires everything together.
using Microsoft.EntityFrameworkCore;
using HospitalApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Dependency Injection: this line is why your controller constructor can ask for ApplicationDbContext.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=hospital.db"));

var app = builder.Build();

// Creates hospital.db when the app starts.
// - No migrations yet?  EnsureCreated builds the tables straight from your model.
// - You made a migration (bonus B7)?  Migrate applies it instead.
// If you switch from the first to the second, delete hospital.db once first.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (db.Database.GetMigrations().Any()) db.Database.Migrate();
    else db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patients}/{action=Index}/{id?}");

app.Run();
