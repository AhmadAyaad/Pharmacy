using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class Supplier_Medicine_Pharamcy_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier_Medicine_Pharmacies",
                columns: table => new
                {
                    Supplier_Medicine_Pharmacy_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    PharmacyId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pharamcy_Supplier_Id = table.Column<int>(type: "int", nullable: true),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_Medicine_Pharmacies", x => x.Supplier_Medicine_Pharmacy_Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Medicine_Pharmacies_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_Medicine_Pharmacies_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_Medicine_Pharmacies_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Medicine_Pharmacies_MedicineId",
                table: "Supplier_Medicine_Pharmacies",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Medicine_Pharmacies_PharmacyId",
                table: "Supplier_Medicine_Pharmacies",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Medicine_Pharmacies_SupplierId",
                table: "Supplier_Medicine_Pharmacies",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier_Medicine_Pharmacies");
        }
    }
}
