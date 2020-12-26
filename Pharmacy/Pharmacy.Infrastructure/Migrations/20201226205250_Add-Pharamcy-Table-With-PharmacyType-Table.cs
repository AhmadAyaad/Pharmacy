using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddPharamcyTableWithPharmacyTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PharmacyType",
                columns: table => new
                {
                    PharmacyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyType", x => x.PharmacyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentPharmacyId = table.Column<int>(type: "int", nullable: true),
                    PharmacyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PharmacyTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.PharmacyId);
                    table.ForeignKey(
                        name: "FK_Pharmacies_Pharmacies_ParentPharmacyId",
                        column: x => x.ParentPharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pharmacies_PharmacyType_PharmacyTypeId",
                        column: x => x.PharmacyTypeId,
                        principalTable: "PharmacyType",
                        principalColumn: "PharmacyTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_ParentPharmacyId",
                table: "Pharmacies",
                column: "ParentPharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_PharmacyTypeId",
                table: "Pharmacies",
                column: "PharmacyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "PharmacyType");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Suppliers");
        }
    }
}
