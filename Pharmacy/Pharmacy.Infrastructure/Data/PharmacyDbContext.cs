using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Infrastructure.EntityConfiguration;

namespace ZPharmacy.Infrastructure.Data
{
    public class PharmacyDbContext : IdentityDbContext<User,Role,string,IdentityUserClaim<string>,UserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PharmacyConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierOrdersConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());

            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new PharmacyOrderDetailsConfiguration());

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<SupplyOrderDetails> SupplyOrderDetails { get; set; }
        public virtual DbSet<SupplyOrders> SupplyOrders { get; set; }
        public virtual DbSet<ProductQuantity> ProductQuantities { get; set; }
        //public virtual DbSet<PharmacyOrderDetails> PharmacyOrderDetails { get; set; }
        //public virtual DbSet<PharmacyOrder> PharmacyOrders { get; set; }
    }
}