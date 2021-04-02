using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpireDates",
                columns: table => new
                {
                    ExpireDateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpireDates", x => x.ExpireDateId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyType",
                columns: table => new
                {
                    PharmacyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyTypeEnum = table.Column<int>(type: "int", nullable: false),
                    ISEligibleToSellToPatients = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyType", x => x.PharmacyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentPharmacyId = table.Column<int>(type: "int", nullable: true),
                    PharmacyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PharmacyTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.PharmacyId);
                    table.ForeignKey(
                        name: "FK_Pharmacies_Pharmacies_ParentPharmacyId",
                        column: x => x.ParentPharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pharmacies_PharmacyType_PharmacyTypeId",
                        column: x => x.PharmacyTypeId,
                        principalTable: "PharmacyType",
                        principalColumn: "PharmacyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImportDetails",
                columns: table => new
                {
                    ProductImportDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportOrderNumber = table.Column<int>(type: "int", nullable: false),
                    SupplyOrderNumber = table.Column<int>(type: "int", nullable: false),
                    ApprovalNumber = table.Column<int>(type: "int", nullable: false),
                    PurchaseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPricePerProduct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImportDetails", x => x.ProductImportDetailsId);
                    table.ForeignKey(
                        name: "FK_ProductImportDetails_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicineName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                    table.ForeignKey(
                        name: "FK_Medicines_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineExpireDate",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    ExpireDateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineExpireDate", x => new { x.MedicineId, x.ExpireDateId });
                    table.ForeignKey(
                        name: "FK_MedicineExpireDate_ExpireDates_ExpireDateId",
                        column: x => x.ExpireDateId,
                        principalTable: "ExpireDates",
                        principalColumn: "ExpireDateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineExpireDate_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientTransactions",
                columns: table => new
                {
                    PatientTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTransactions", x => x.PatientTransactionId);
                    table.ForeignKey(
                        name: "FK_PatientTransactions_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientTransactions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientTransactions_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProductsTransfers",
                columns: table => new
                {
                    SupplierProductsTransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductImportDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProductsTransfers", x => x.SupplierProductsTransferId);
                    table.ForeignKey(
                        name: "FK_SupplierProductsTransfers_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierProductsTransfers_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierProductsTransfers_ProductImportDetails_ProductImportDetailsId",
                        column: x => x.ProductImportDetailsId,
                        principalTable: "ProductImportDetails",
                        principalColumn: "ProductImportDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineExpireDate_ExpireDateId",
                table: "MedicineExpireDate",
                column: "ExpireDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineName",
                table: "Medicines",
                column: "MedicineName");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_UnitId",
                table: "Medicines",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_MedicineId",
                table: "PatientTransactions",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_PatientId",
                table: "PatientTransactions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTransactions_PharmacyId",
                table: "PatientTransactions",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_ParentPharmacyId",
                table: "Pharmacies",
                column: "ParentPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_PharmacyTypeId",
                table: "Pharmacies",
                column: "PharmacyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImportDetails_SupplierId",
                table: "ProductImportDetails",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductsTransfers_MedicineId",
                table: "SupplierProductsTransfers",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductsTransfers_PharmacyId",
                table: "SupplierProductsTransfers",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductsTransfers_ProductImportDetailsId",
                table: "SupplierProductsTransfers",
                column: "ProductImportDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineExpireDate");

            migrationBuilder.DropTable(
                name: "PatientTransactions");

            migrationBuilder.DropTable(
                name: "SupplierProductsTransfers");

            migrationBuilder.DropTable(
                name: "ExpireDates");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "ProductImportDetails");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "PharmacyType");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}