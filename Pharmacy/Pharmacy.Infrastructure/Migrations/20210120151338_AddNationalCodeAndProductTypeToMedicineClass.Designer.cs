﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy.Infrastructure.Data;

namespace Pharmacy.Infrastructure.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    [Migration("20210120151338_AddNationalCodeAndProductTypeToMedicineClass")]
    partial class AddNationalCodeAndProductTypeToMedicineClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Pharmacy.Domain.Entities.Medicine", b =>
                {
                    b.Property<int>("MedicineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicineCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("MedicineId");

                    b.HasIndex("MedicineName");

                    b.HasIndex("UnitId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.PatientTransaction", b =>
                {
                    b.Property<int>("PatientTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PatientTransactionId");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("PatientTransactions");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Pharmacy", b =>
                {
                    b.Property<int>("PharmacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ParentPharmacyId")
                        .HasColumnType("int");

                    b.Property<string>("PharmacyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("PharmacyTypeId")
                        .HasColumnType("int");

                    b.HasKey("PharmacyId");

                    b.HasIndex("ParentPharmacyId");

                    b.HasIndex("PharmacyTypeId");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.PharmacyType", b =>
                {
                    b.Property<int>("PharmacyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("ISEligibleToSellToPatients")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PharmacyTypeId");

                    b.ToTable("PharmacyType");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Supplier_Medicine_Pharmacy", b =>
                {
                    b.Property<int>("Supplier_Medicine_Pharmacy_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int?>("Pharamcy_Supplier_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Supplier_Medicine_Pharmacy_Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PharmacyId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Supplier_Medicine_Pharmacies");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Medicine", b =>
                {
                    b.HasOne("Pharmacy.Domain.Entities.Unit", "Unit")
                        .WithMany("Medicines")
                        .HasForeignKey("UnitId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.PatientTransaction", b =>
                {
                    b.HasOne("Pharmacy.Domain.Entities.Medicine", "Medicine")
                        .WithMany("PatientTransactions")
                        .HasForeignKey("MedicineId");

                    b.HasOne("Pharmacy.Domain.Entities.Patient", "Patient")
                        .WithMany("PatientTransactions")
                        .HasForeignKey("PatientId");

                    b.HasOne("Pharmacy.Domain.Entities.Pharmacy", "Pharmacy")
                        .WithMany("PatientTransactions")
                        .HasForeignKey("PharmacyId");

                    b.Navigation("Medicine");

                    b.Navigation("Patient");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Pharmacy", b =>
                {
                    b.HasOne("Pharmacy.Domain.Entities.Pharmacy", "ParentPharmacy")
                        .WithMany("ChildrenPharmacies")
                        .HasForeignKey("ParentPharmacyId");

                    b.HasOne("Pharmacy.Domain.Entities.PharmacyType", "PharmacyType")
                        .WithMany("Pharmacies")
                        .HasForeignKey("PharmacyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentPharmacy");

                    b.Navigation("PharmacyType");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Supplier_Medicine_Pharmacy", b =>
                {
                    b.HasOne("Pharmacy.Domain.Entities.Medicine", "Medicine")
                        .WithMany("Supplier_Medicine_Pharmacies")
                        .HasForeignKey("MedicineId");

                    b.HasOne("Pharmacy.Domain.Entities.Pharmacy", "Pharmacy")
                        .WithMany("Supplier_Medicine_Pharmacies")
                        .HasForeignKey("PharmacyId");

                    b.HasOne("Pharmacy.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Supplier_Medicine_Pharmacies")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Medicine");

                    b.Navigation("Pharmacy");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Medicine", b =>
                {
                    b.Navigation("PatientTransactions");

                    b.Navigation("Supplier_Medicine_Pharmacies");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Patient", b =>
                {
                    b.Navigation("PatientTransactions");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Pharmacy", b =>
                {
                    b.Navigation("ChildrenPharmacies");

                    b.Navigation("PatientTransactions");

                    b.Navigation("Supplier_Medicine_Pharmacies");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.PharmacyType", b =>
                {
                    b.Navigation("Pharmacies");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Supplier", b =>
                {
                    b.Navigation("Supplier_Medicine_Pharmacies");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Unit", b =>
                {
                    b.Navigation("Medicines");
                });
#pragma warning restore 612, 618
        }
    }
}
