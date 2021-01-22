using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class LinkExpDateToMedicineM2M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MedicineExpireDate",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    ExpireDateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineExpireDate", x => new { x.MedicineId, x.ExpireDateId });
                    table.ForeignKey(
                        name: "FK_MedicineExpireDate_ExpireDates_ExpireDateId",
                        column: x => x.ExpireDateId,
                        principalTable: "ExpireDates",
                        principalColumn: "ExpireDateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineExpireDate_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineExpireDate_ExpireDateId",
                table: "MedicineExpireDate",
                column: "ExpireDateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineExpireDate");

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
    }
}
