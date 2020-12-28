using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class Change_Medicine_Unit_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Medicines_MedicineId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MedicineId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Medicines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_UnitId",
                table: "Medicines",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Units_UnitId",
                table: "Medicines",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Units_UnitId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_UnitId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Medicines");

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_MedicineId",
                table: "Units",
                column: "MedicineId",
                unique: true,
                filter: "[MedicineId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Medicines_MedicineId",
                table: "Units",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
