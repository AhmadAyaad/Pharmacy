using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Infrastructure.Data
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Medicine config
            modelBuilder.Entity<Medicine>().Property(m => m.MedicineName)
                                           .IsRequired()
                                           .HasMaxLength(255);

            modelBuilder.Entity<Medicine>().HasIndex(m => m.MedicineName);



            modelBuilder.Entity<Medicine>().HasMany(s => s.Supplier_Medicine_Pharmacies)
                                           .WithOne(smp => smp.Medicine);

            modelBuilder.Entity<Medicine>()
                        .HasMany(m => m.PatientTransactions)
                        .WithOne(pt => pt.Medicine);

            #endregion

            #region ExpireDate Medicine Config

            modelBuilder.Entity<MedicineExpireDate>()
                        .HasKey(med => new { med.MedicineId, med.ExpireDateId });
            modelBuilder.Entity<MedicineExpireDate>()
                        .HasOne(med => med.Medicine)
                        .WithMany(b => b.MedicineExpireDates)
                        .HasForeignKey(med => med.MedicineId);
            modelBuilder.Entity<MedicineExpireDate>()
                        .HasOne(med => med.ExpireDate)
                        .WithMany(c => c.MedicineExpireDates)
                        .HasForeignKey(med => med.ExpireDateId);
            #endregion
            #region Unit Config
            modelBuilder.Entity<Unit>().Property(u => u.UnitName).IsRequired();

            modelBuilder.Entity<Unit>()
                        .HasMany(c => c.Medicines)
                        .WithOne(e => e.Unit);
            #endregion

            //#region Medicine Unit Config
            //modelBuilder.Entity<Medicine>()
            //            .HasOne(med => med.Unit)
            //            .WithOne(unit => unit.Medicine)
            //            .HasForeignKey<Unit>(b => b.MedicineId);
            //#endregion

            #region Supplier Config

            modelBuilder.Entity<Supplier>().Property(s => s.SupplierName)
                                            .IsRequired()
                                            .HasMaxLength(255);

            modelBuilder.Entity<Supplier>().HasMany(s => s.Supplier_Medicine_Pharmacies)
                                           .WithOne(smp => smp.Supplier);
            #endregion


            #region Pharmacy Config

            //self relation
            modelBuilder.Entity<Pharmacy.Domain.Entities.Pharmacy>()
                        .HasOne(ph => ph.ParentPharmacy)
                        .WithMany(ph => ph.ChildrenPharmacies)
                        .HasForeignKey(ph => ph.ParentPharmacyId);

            modelBuilder.Entity<Pharmacy.Domain.Entities.Pharmacy>()
                        .Property(ph => ph.PharmacyName)
                        .IsRequired().HasMaxLength(255);


            modelBuilder.Entity<Pharmacy.Domain.Entities.Pharmacy>()
                        .HasMany(ph => ph.Supplier_Medicine_Pharmacies)
                        .WithOne(smp => smp.Pharmacy);


            modelBuilder.Entity<Pharmacy.Domain.Entities.Pharmacy>()
                        .HasMany(ph => ph.PatientTransactions)
                        .WithOne(pt => pt.Pharmacy);


            #endregion


            #region Pharamcy Type Config 
            modelBuilder.Entity<PharmacyType>()
                        .HasMany(pt => pt.Pharmacies)
                        .WithOne(p => p.PharmacyType)
                        .OnDelete(DeleteBehavior.Cascade);

            #endregion


            #region Supplier_Medicine_Pharmacy Config

            modelBuilder.Entity<Supplier_Medicine_Pharmacy>().HasKey(smp => smp.Supplier_Medicine_Pharmacy_Id);

            #endregion


            #region Patient Config 

            modelBuilder.Entity<Patient>()
                        .HasMany(ph => ph.PatientTransactions)
                        .WithOne(pt => pt.Patient);

            #endregion



            #region PorudtcImportDetails Config

            #endregion



            modelBuilder.Entity<Pharmacy.Infrastructure.Views.PharmacyProducts>(eb =>
                          {
                              eb.HasNoKey();
                              eb.ToView("View_pharmacyProducts");
                          }
                          );

        }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<ExpireDate> ExpireDates { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Pharmacy.Domain.Entities.Pharmacy> Pharmacies { get; set; }
        public virtual DbSet<Supplier_Medicine_Pharmacy> Supplier_Medicine_Pharmacies { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientTransaction> PatientTransactions { get; set; }
        public virtual DbSet<ProductImportDetails> ProductImportDetails { get; set; }
        public virtual DbSet<Pharmacy.Infrastructure.Views.PharmacyProducts> PharmacyProducts { get; set; }


    }
}
