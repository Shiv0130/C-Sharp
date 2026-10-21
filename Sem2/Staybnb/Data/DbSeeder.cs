using Microsoft.AspNetCore.Identity;
using Staybnb.Models;

namespace Staybnb.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles =
            {
                AppRoles.Guest,
                AppRoles.Host,
                AppRoles.Admin,
                AppRoles.SuperAdmin
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            const string superEmail = "superadmin@staybnb.local";
            const string superPassword = "SuperAdmin@123";

            var superUser = await userManager.FindByEmailAsync(superEmail);
            if (superUser == null)
            {
                superUser = new ApplicationUser
                {
                    UserName = superEmail,
                    Email = superEmail,
                    EmailConfirmed = true,
                    FirstName = "Super",
                    LastName = "Admin",
                    CreatedAt = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(superUser, superPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superUser, AppRoles.SuperAdmin);
                    await userManager.AddToRoleAsync(superUser, AppRoles.Admin);
                }
            }
        }
    }
}
