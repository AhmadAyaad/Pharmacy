using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddProductImportDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImportDetails",
                columns: table => new
                {
                    ProductImportDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportOrderNumber = table.Column<int>(type: "int", nullable: false),
                    SupplyOrderNumber = table.Column<int>(type: "int", nullable: false),
                    PurchaseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Supplier_Medicine_Pharmacy_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImportDetails", x => x.ProductImportDetailsId);
                    table.ForeignKey(
                        name: "FK_ProductImportDetails_Supplier_Medicine_Pharmacies_Supplier_Medicine_Pharmacy_Id",
                        column: x => x.Supplier_Medicine_Pharmacy_Id,
                        principalTable: "Supplier_Medicine_Pharmacies",
                        principalColumn: "Supplier_Medicine_Pharmacy_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImportDetails_Supplier_Medicine_Pharmacy_Id",
                table: "ProductImportDetails",
                column: "Supplier_Medicine_Pharmacy_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImportDetails");
        }
    }
}
