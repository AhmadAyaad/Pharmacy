using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class MakeMedicineIdUnitTableNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Medicines_MedicineId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MedicineId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Medicines_MedicineId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_MedicineId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_MedicineId",
                table: "Units",
                column: "MedicineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Medicines_MedicineId",
                table: "Units",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
