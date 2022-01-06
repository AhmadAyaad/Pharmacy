using Microsoft.Extensions.DependencyInjection;
using System;
using ZPharmacy.Core.IServices;
using ZPharmacy.Core.Services;

namespace ZPharmacy.Core.Extensions
{
    public static class CoreExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ISupplierService, SupplierService>();
            //services.AddScoped<IProductImportDetailsService, ProductImportDetailsService>();
            services.AddScoped<IPharamcyService, PharmacyService>();
            //services.AddScoped<IProductSupplierService, ProductSupplierService>();
            services.AddScoped<ISupplyOrderService, SupplyOrderService>();

        }
    }
}

