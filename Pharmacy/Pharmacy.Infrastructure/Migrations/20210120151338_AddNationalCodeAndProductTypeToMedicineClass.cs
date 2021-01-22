using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddNationalCodeAndProductTypeToMedicineClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Medicines");
        }
    }
}
