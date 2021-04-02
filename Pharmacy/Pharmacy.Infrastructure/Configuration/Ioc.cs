using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Interfaces;
using Pharmacy.Infrastructure.Data;
using Pharmacy.Infrastructure.Repostiory;
using Pharmacy.Infrastructure.UnitOfWork;

namespace Pharmacy.Infrastructure.Configuration
{
    public class Ioc
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PharmacyDbContext>(options => options.UseSqlServer(connectionString));
            //pharmacy
            services.AddScoped<IRepository<Pharmacy.Domain.Entities.Pharmacy>,
                                Repository<Pharmacy.Domain.Entities.Pharmacy>>();
            services.AddScoped<IPharmacyRepository, PharmacyRepository>();

            //unitofwork
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            //Medicine || Product
            services.AddScoped<IRepository<Medicine>, Repository<Medicine>>();
            services.AddScoped<IMedicineRepository, MedicineRepoistory>();

            // Unit
            services.AddScoped<IRepository<Unit>, Repository<Unit>>();
            services.AddScoped<IUnitRepository, UnitReposiotry>();

            //Supplier
            services.AddScoped<IRepository<Supplier>, Repository<Supplier>>();

            //productImportDetails
            services.AddScoped<IRepository<ProductImportDetails>,
                                Repository<ProductImportDetails>>();

            //SupplierProductsTransfer
            services.AddScoped<IRepository<SupplierProductsTransfer>,
                                Repository<SupplierProductsTransfer>>();
            services.AddScoped<ISupplierProductsTransferReposiotry,
                                SupplierProductsTransferReposiotry>();

            //ProductsQuantity
            services.AddScoped<IRepository<ProductsQuantity>, Repository<ProductsQuantity>>();

            //PharmacySupplyDetails
            services.AddScoped<IRepository<PharmacySupplyDetails>, Repository<PharmacySupplyDetails>>();

            //PharmacyProductsTransfer
            services.AddScoped<IRepository<PharmacyProductsTransfer>, Repository<PharmacyProductsTransfer>>();
        }
    }
}