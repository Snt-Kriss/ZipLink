using Microsoft.AspNetCore.Identity;
using ZipLink.Client.Helpers.Roles;
using ZipLink.Data.Models;

namespace ZipLink.Client.Data
{
    public static class DbSeeder
    {
        //public static void SeedDefaultData(IApplicationBuilder applicationBuilder)
        //{
        //    //CreateScope creates a new scope within application service provider. Scopes manage lifetime of an object
        //    using(var serviceScope= applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

        //        if (!dbContext.Users.Any())
        //        {
        //            dbContext.Users.AddRange(new AppUser(){
        //                FullName= "Crispus Munene",
        //                Email="mwangikriss356@gmail.com"
        //            });

        //            dbContext.SaveChanges();
        //        }

        //        if (!dbContext.Urls.Any())
        //        {
        //            dbContext.Urls.AddRange(new Url()
        //            {
        //                OriginalLink = "https://www.google.com",
        //                ShortLink = "123",
        //                NumberOfClicks = 1,
        //                UserId = dbContext.Users.First().Id,
        //                DateCreated= DateTime.Now
        //            });

        //            dbContext.SaveChanges();
        //        }
        //    }
        //}

        public static async Task SeedDefaulUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                //User data
                var simpleUserRole = Role.User;
                var simpleUserEmail = "user@ziplink.com";
                if (!await roleManager.RoleExistsAsync(simpleUserRole))
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = simpleUserRole });
                }

                if (await userManager.FindByEmailAsync(simpleUserEmail) == null)
                {
                    var simpleUser = new AppUser()
                    {
                        FullName = "Simple User",
                        UserName = "simple-user",
                        Email = simpleUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(simpleUser, "19982001-cH");

                    //add user to role
                    await userManager.AddToRoleAsync(simpleUser, simpleUserRole);
                }

                //Admin data
                var adminUserRole = Role.Admin;
                var adminUserEmail = "admin@ziplink.com";
                if (!await roleManager.RoleExistsAsync(adminUserRole))
                    await roleManager.CreateAsync(new IdentityRole() { Name = adminUserRole });

                if (await userManager.FindByEmailAsync(adminUserEmail) == null)
                {
                    var adminUser = new AppUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(adminUser, "19982001-cH");

                    //add user to role
                    await userManager.AddToRoleAsync(adminUser, adminUserRole);
                }
            }
        }
    }
}
