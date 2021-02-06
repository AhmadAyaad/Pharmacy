using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddPharamcyTypeEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PharmacyType");

            migrationBuilder.AddColumn<int>(
                name: "PharmacyTypeEnum",
                table: "PharmacyType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmacyTypeEnum",
                table: "PharmacyType");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PharmacyType",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
