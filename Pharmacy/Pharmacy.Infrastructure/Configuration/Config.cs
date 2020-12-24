using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Infrastructure.Data;
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
        }
    }
}
