using App.Domain.Constans;
using App.Infrastructure.Entitie;
using Microsoft.AspNetCore.Identity;


namespace App.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Authorizations.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorizations.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorizations.Roles.User.ToString()));
        }
    }
}
