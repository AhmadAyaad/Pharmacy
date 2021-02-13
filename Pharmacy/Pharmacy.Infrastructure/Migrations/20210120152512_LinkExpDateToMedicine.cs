using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class LinkExpDateToMedicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Medicines");

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "ExpireDates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpireDates_MedicineId",
                table: "ExpireDates",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpireDates_Medicines_MedicineId",
                table: "ExpireDates",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpireDates_Medicines_MedicineId",
                table: "ExpireDates");

            migrationBuilder.DropIndex(
                name: "IX_ExpireDates_MedicineId",
                table: "ExpireDates");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "ExpireDates");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Medicines",
                type: "datetime2",
                nullable: true);
        }
    }
}
