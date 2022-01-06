using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Shared.Models;

namespace SimpleFantasy.Infrastructure
{
    public class PharmacyDbContextSeed
    {
        //public static async Task SeedEssentialsAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        public static async Task SeedEssentialsAsync(IServiceProvider serviceProvider)
        {
            //Seed Roles
            bool created = false;
            using (var scope = serviceProvider.CreateScope())
            {
                var rolesManager = scope.ServiceProvider.GetService<RoleManager<Role>>();
                var rolesExisted = rolesManager.Roles.Any();
                if (!rolesExisted)
                {
                    await rolesManager.CreateAsync(new Role { Name = Authorization.Roles.Admin.ToString() });
                    await rolesManager.CreateAsync(new Role { Name = Authorization.Roles.User.ToString() });
                    created = true;
                }
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                var adminUser = userManager.Users.FirstOrDefault(u => u.UserName == Authorization.DEFAULT_ADMIN_USERNAME);
                if (adminUser == null)
                {
                    var user = new User { UserName = Authorization.DEFAULT_ADMIN_USERNAME, Email = Authorization.DEFAULT_ADMIN_EMAIL };
                    await userManager.CreateAsync(user, Authorization.DEFAULT_ADMIN_PASSWORD);
                    await userManager.AddToRoleAsync(user, Authorization.ADMIN_ROLE.ToString());
                    created = true;
                }
            }
            //await roleManager.CreateAsync(new Role { Name = Authorization.Roles.Admin.ToString() });
            //await roleManager.CreateAsync(new Role { Name = Authorization.Roles.User.ToString() });
            ////Seed Default User
            //var defaultUser = new User { UserName = Authorization.DEFAULT_ADMIN_USERNAME, Email = Authorization.DEFAULT_ADMIN_EMAIL, EmailConfirmed = true, PhoneNumberConfirmed = true };
            //if (userManager.Users.All(u => u.Id != defaultUser.Id))
            //{
            //    await userManager.CreateAsync(defaultUser, Authorization.DEFAULT_ADMIN_PASSWORD);
            //    await userManager.AddToRoleAsync(defaultUser, Authorization.ADMIN_ROLE.ToString());
            //}
        }
    }
}
