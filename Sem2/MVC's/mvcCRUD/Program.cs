using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcCRUD.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Reads the "DefaultConnection" string from appsettings.json / appsettings.Development.json
// (or user-secrets), and fails fast at startup if it's missing.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Registers ASP.NET Core Identity (login/register/etc.) using ApplicationDbContext
// as the store, with IdentityUser as the user model.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// NOTE (not changed, just flagging for you): there's no app.UseAuthentication() call
// here before app.UseAuthorization(). For Identity login (cookie auth) to correctly
// populate the logged-in user on each request, ASP.NET Core normally expects:
//   app.UseAuthentication();
//   app.UseAuthorization();
// in that order. Worth adding if you notice [Authorize] pages not recognizing a
// logged-in user - left out here since you asked to keep the code as-is.
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
