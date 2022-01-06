using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZPharmacy.Infrastructure.Data;
using ZPharmacy.Infrastructure.UnitOfWork;

namespace ZPharmacy.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddInfrastrucuteServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PharmacyDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}