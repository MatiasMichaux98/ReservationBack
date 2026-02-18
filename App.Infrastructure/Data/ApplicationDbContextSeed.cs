using App.Domain.Constans;
using App.Infrastructure.Entitie;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace App.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialAsync(UserManager<ApplicationUser> userManager, 
                                                    RoleManager<IdentityRole> roleManager,
                                                    IConfiguration configuration)
        {
            foreach (var roleName in Enum.GetNames(typeof(Authorizations.Roles)))
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                    await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var adminEmail = configuration["AdminUser:Email"];
            var adminPassword = configuration["AdminUser:Password"];
            var adminFirstName = configuration["AdminUser:FirstName"];
            var adminLastName = configuration["AdminUser:LastName"];

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if(adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = adminFirstName,
                    LastName = adminLastName
                };
               var result =  await userManager.CreateAsync(adminUser, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(" | ",
                        result.Errors.Select(e => e.Code + ": " + e.Description)));
                }
                await userManager.AddToRoleAsync(adminUser, Authorizations.Roles.Administrator.ToString());
            }
        }
    }
}
