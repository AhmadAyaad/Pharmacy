﻿using Microsoft.Extensions.DependencyInjection;

using Pharmacy.Core.Interfaces;
using Pharmacy.Core.Services;

namespace Pharmacy.Core.Configuration
{
    public class Ioc
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductImportDetailsService, ProductImportDetailsService>();
            services.AddScoped<IPharamcyService, PharmacyService>();
            services.AddScoped<IProductSupplierService, ProductSupplierService>();

        }
    }
}

