using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class CreatePharmacyProductsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE VIEW View_pharmacyProducts as 
                        select SUM(Quantity) as Quantity
                        , MedicineName ,
			            Supplier_Medicine_Pharmacies.PharmacyId,
                        PharmacyName,
			            SupplierName,
                        Price,
                        Supplier_Medicine_Pharmacies.CreatedAt
                        from Medicines
                        inner join Supplier_Medicine_Pharmacies 
                        on Supplier_Medicine_Pharmacies.MedicineId = Medicines.MedicineId
                        inner join Pharmacies
                        on Pharmacies.PharmacyId=Supplier_Medicine_Pharmacies.PharmacyId
                        inner join Suppliers
                        on Suppliers.SupplierId =Supplier_Medicine_Pharmacies.SupplierId
                        group by MedicineName,Pharmacies.PharmacyName, SupplierName,price,
                        Supplier_Medicine_Pharmacies.CreatedAt ,Supplier_Medicine_Pharmacies.PharmacyId
                        ";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW View_pharmacyProducts");
        }
    }
}
