using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Repostiory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Infrastructure.Configuration
{
    public class Config
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository<Medicine>, MedicineRepository>();
            services.AddScoped<IRepository<Supplier>, SupplierRepository>();
            services.AddScoped<IRepository<Unit>, UnitRepository>();
        }
    }
}
