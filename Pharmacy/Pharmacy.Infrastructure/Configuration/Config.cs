using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Repostiory;
using Pharmacy.Infrastructure.UnitOfWork;
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
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IRepository<Medicine>, Repository<Medicine>>();
            services.AddScoped<IRepository<Unit>, Repository<Unit>>();
            services.AddScoped<IRepository<Supplier>, Repository<Supplier>>();



        }
    }
}
