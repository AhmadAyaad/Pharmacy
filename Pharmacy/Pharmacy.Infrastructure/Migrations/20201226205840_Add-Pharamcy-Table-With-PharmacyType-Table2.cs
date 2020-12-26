using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddPharamcyTableWithPharmacyTypeTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_PharmacyType_PharmacyTypeId",
                table: "Pharmacies");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_PharmacyType_PharmacyTypeId",
                table: "Pharmacies",
                column: "PharmacyTypeId",
                principalTable: "PharmacyType",
                principalColumn: "PharmacyTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_PharmacyType_PharmacyTypeId",
                table: "Pharmacies");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_PharmacyType_PharmacyTypeId",
                table: "Pharmacies",
                column: "PharmacyTypeId",
                principalTable: "PharmacyType",
                principalColumn: "PharmacyTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
