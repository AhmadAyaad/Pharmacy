using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleFantasy.Identity.Services;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Identity.IServices;
using ZPharmacy.Infrastructure;
using ZPharmacy.Infrastructure.Data;

namespace ZPharmacy.Identity.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = true;
            })
            .AddRoles<Role>().AddEntityFrameworkStores<PharmacyDbContext>().AddDefaultTokenProviders()
            .AddUserManager<ApplicationUserManager>()
            .AddUserStore<UserStore<User, Role, PharmacyDbContext, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>>()
            .AddRoleStore<RoleStore<Role, PharmacyDbContext, string, UserRole, IdentityRoleClaim<string>>>();

            services.AddScoped<IAccountService, AccountService>();


        }
    }
}
