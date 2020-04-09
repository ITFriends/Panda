using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ITFriends.Panda.Utilities;

namespace ITFriends.Panda.Models
{
    public class InitialData
    {
        public static async Task Seed(PandaDbContext context,
                            UserManager<ApplicationUser> userManager,
                            RoleManager<ApplicationRole> roleManager, 
                            IConfiguration configuration)
        {
            context.Database.EnsureCreated();

            //SamaritanDbContext context2 = app.ApplicationServices.GetRequiredService<SamaritanDbContext>();
            //context2.Database.Migrate();

            if (await roleManager.FindByNameAsync(Roles.Admin) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(Roles.Admin, Roles.AdminDesc));
            }

            if (await roleManager.FindByNameAsync(Roles.User) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(Roles.User, Roles.UserDesc));
            }

            if ((await userManager.GetUsersInRoleAsync(Roles.Admin)).Count == 0)
            {
                var user = new ApplicationUser
                {
                    UserName = configuration["Authentication:AdminEmail"],
                    Email = configuration["Authentication:AdminEmail"]
                };

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, configuration["Authentication:AdminPass"]);
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                }
            }
        }
    }
}
