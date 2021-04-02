using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddPharmacyProductsTransferEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PharmacyProductsTransfer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    pharmacy_Recviver_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PharmacySupplyDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyProductsTransfer", x => x.id);
                    table.ForeignKey(
                        name: "FK_PharmacyProductsTransfer_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PharmacyProductsTransfer_Pharmacies_pharmacy_Recviver_Id",
                        column: x => x.pharmacy_Recviver_Id,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PharmacyProductsTransfer_PharmacySupplyDetails_PharmacySupplyDetailsId",
                        column: x => x.PharmacySupplyDetailsId,
                        principalTable: "PharmacySupplyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductsTransfer_MedicineId",
                table: "PharmacyProductsTransfer",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductsTransfer_pharmacy_Recviver_Id",
                table: "PharmacyProductsTransfer",
                column: "pharmacy_Recviver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProductsTransfer_PharmacySupplyDetailsId",
                table: "PharmacyProductsTransfer",
                column: "PharmacySupplyDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyProductsTransfer");
        }
    }
}
