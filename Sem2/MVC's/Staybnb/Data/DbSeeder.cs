using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // ----- Roles -----
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

            // ----- SuperAdmin -----
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

            // ----- Demo Host (already approved style) -----
            const string hostEmail = "host@staybnb.local";
            const string hostPassword = "Host@123456";

            var hostUser = await userManager.FindByEmailAsync(hostEmail);
            if (hostUser == null)
            {
                hostUser = new ApplicationUser
                {
                    UserName = hostEmail,
                    Email = hostEmail,
                    EmailConfirmed = true,
                    FirstName = "Elsie",
                    LastName = "Masuku",
                    CreatedAt = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(hostUser, hostPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(hostUser, AppRoles.Host);
                }
            }
            else
            {
                // Ensure host role
                if (!await userManager.IsInRoleAsync(hostUser, AppRoles.Host))
                {
                    await userManager.AddToRoleAsync(hostUser, AppRoles.Host);
                }
            }

            // ----- Demo Guest -----
            const string guestEmail = "guest@staybnb.local";
            const string guestPassword = "Guest@123456";

            var guestUser = await userManager.FindByEmailAsync(guestEmail);
            if (guestUser == null)
            {
                guestUser = new ApplicationUser
                {
                    UserName = guestEmail,
                    Email = guestEmail,
                    EmailConfirmed = true,
                    FirstName = "Thabo",
                    LastName = "Ndlovu",
                    CreatedAt = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(guestUser, guestPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(guestUser, AppRoles.Guest);
                }
            }

            // ----- Sample properties (only if none exist) -----
            if (!await context.HostProperties.AnyAsync())
            {
                // Refresh host id
                hostUser = await userManager.FindByEmailAsync(hostEmail);
                if (hostUser == null) return;

                var samples = new List<(HostProperty Prop, string[] Images)>
                {
                    (
                        new HostProperty
                        {
                            Title = "Luxury Apartment",
                            Description = "Modern luxury apartment with pool access, high-speed Wi‑Fi, and city views. Perfect for couples or business travellers.",
                            PricePerNight = 1320m,
                            Address = "12 Ocean Drive",
                            City = "Durban",
                            PropertyType = "Apartment",
                            IsActive = true,
                            HostId = hostUser.Id
                        },
                        new[]
                        {
                            "https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=800&q=80",
                            "https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=800&q=80"
                        }
                    ),
                    (
                        new HostProperty
                        {
                            Title = "Exceptional Villa in Nature",
                            Description = "Spacious villa surrounded by nature. Braai area, large garden, and peaceful mornings.",
                            PricePerNight = 2450m,
                            Address = "88 Valley Road",
                            City = "Drakensberg",
                            PropertyType = "Villa",
                            IsActive = true,
                            HostId = hostUser.Id
                        },
                        new[]
                        {
                            "https://images.unsplash.com/photo-1613490493576-7fde63acd811?w=800&q=80",
                            "https://images.unsplash.com/photo-1600596542815-ffad4c1539a9?w=800&q=80"
                        }
                    ),
                    (
                        new HostProperty
                        {
                            Title = "Cozy 3 Bedroom House",
                            Description = "Family-friendly house close to shops and schools. Fully equipped kitchen and secure parking.",
                            PricePerNight = 980m,
                            Address = "45 Maple Street",
                            City = "Pretoria",
                            PropertyType = "House",
                            IsActive = true,
                            HostId = hostUser.Id
                        },
                        new[]
                        {
                            "https://images.unsplash.com/photo-1568605114967-8130f3a36994?w=800&q=80",
                            "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=800&q=80"
                        }
                    ),
                    (
                        new HostProperty
                        {
                            Title = "Cozy Forest Cabin",
                            Description = "Escape to this cozy forest cabin tucked among towering trees. Rustic charm, fireplace, and forest views.",
                            PricePerNight = 3100m,
                            Address = "7 Pine Trail",
                            City = "Durban",
                            PropertyType = "Cabin",
                            IsActive = true,
                            HostId = hostUser.Id
                        },
                        new[]
                        {
                            "https://images.unsplash.com/photo-1449158743715-0a90ebb6d2d8?w=800&q=80",
                            "https://images.unsplash.com/photo-1518780664697-55e3d943a1a2?w=800&q=80"
                        }
                    ),
                    (
                        new HostProperty
                        {
                            Title = "Exceptional Holiday Flat",
                            Description = "Bright holiday flat near the beach promenade. Walk to restaurants and nightlife.",
                            PricePerNight = 1100m,
                            Address = "3 Beach Road",
                            City = "Cape Town",
                            PropertyType = "Apartment",
                            IsActive = true,
                            HostId = hostUser.Id
                        },
                        new[]
                        {
                            "https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=800&q=80",
                            "https://images.unsplash.com/photo-1493809842364-78817add7ffb?w=800&q=80"
                        }
                    ),
                    (
                        new HostProperty
                        {
                            Title = "Beautiful Beachfront Suite",
                            Description = "Wake up to ocean views. Direct beach access, balcony, and premium linen.",
                            PricePerNight = 1890m,
                            Address = "21 Lagoon Avenue",
                            City = "Umhlanga",
                            PropertyType = "Apartment",
                            IsActive = true,
                            HostId = hostUser.Id
                        },
                        new[]
                        {
                            "https://images.unsplash.com/photo-1499793983690-e29da59ef1c2?w=800&q=80",
                            "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?w=800&q=80"
                        }
                    )
                };

                foreach (var sample in samples)
                {
                    context.HostProperties.Add(sample.Prop);
                    await context.SaveChangesAsync();

                    foreach (var url in sample.Images)
                    {
                        context.PropertyImages.Add(new PropertyImage
                        {
                            PropertyId = sample.Prop.Id,
                            ImageUrl = url
                        });
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
