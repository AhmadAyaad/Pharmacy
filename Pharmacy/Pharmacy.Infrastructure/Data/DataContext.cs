using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Medicine config
            modelBuilder.Entity<Medicine>().Property(m => m.MedicineName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Medicine>().HasIndex(m => m.MedicineName);
            modelBuilder.Entity<Medicine>().Property(m => m.SellingPrice).IsRequired();
            modelBuilder.Entity<Medicine>().Property(m => m.MedicineCode).IsRequired();

            #endregion



            #region Unit Config
            modelBuilder.Entity<Unit>().Property(u => u.UnitName).IsRequired();
            #endregion



            #region Medicine Unit Config
            modelBuilder.Entity<Medicine>()
                .HasOne(med => med.Unit)
                .WithOne(unit => unit.Medicine)
                .HasForeignKey<Unit>(b => b.MedicineId);
            #endregion



        }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
    }
}
