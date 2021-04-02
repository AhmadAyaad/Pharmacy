using Microsoft.EntityFrameworkCore.Migrations;

using System;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddProductsQuantityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsQuantities",
                columns: table => new
                {
                    ProductsQuantityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    TotalProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsQuantities", x => x.ProductsQuantityId);
                    table.ForeignKey(
                        name: "FK_ProductsQuantities_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsQuantities_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsQuantities_MedicineId",
                table: "ProductsQuantities",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsQuantities_PharmacyId",
                table: "ProductsQuantities",
                column: "PharmacyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsQuantities");
        }
    }
}