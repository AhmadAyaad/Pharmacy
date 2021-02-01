using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Core.Interfaces;
using Pharmacy.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Configuration
{
    public class Config
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductImportDetailsService, ProductImportDetailsService>();
            services.AddScoped<ISupplierMedicinePharamcyService, SupplierMedicinePharamcyService>();

        }
    }
}

