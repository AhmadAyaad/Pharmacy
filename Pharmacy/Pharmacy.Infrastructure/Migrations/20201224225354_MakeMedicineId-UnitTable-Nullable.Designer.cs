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
    [DbContext(typeof(DataContext))]
    [Migration("20201224225354_MakeMedicineId-UnitTable-Nullable")]
    partial class MakeMedicineIdUnitTableNullable
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

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicineCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MedicineId");

                    b.HasIndex("MedicineName");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitId");

                    b.HasIndex("MedicineId")
                        .IsUnique()
                        .HasFilter("[MedicineId] IS NOT NULL");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Unit", b =>
                {
                    b.HasOne("Pharmacy.Domain.Entities.Medicine", "Medicine")
                        .WithOne("Unit")
                        .HasForeignKey("Pharmacy.Domain.Entities.Unit", "MedicineId");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("Pharmacy.Domain.Entities.Medicine", b =>
                {
                    b.Navigation("Unit");
                });
#pragma warning restore 612, 618
        }
    }
}
