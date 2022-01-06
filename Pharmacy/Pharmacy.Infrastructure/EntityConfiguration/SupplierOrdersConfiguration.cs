using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Infrastructure.EntityConfiguration
{
    internal class SupplierOrdersConfiguration : IEntityTypeConfiguration<SupplyOrders>
    {
        public void Configure(EntityTypeBuilder<SupplyOrders> builder)
        {
            builder.HasKey(so => so.Id);
            builder.HasIndex(so => so.ImportOrderNumber).IsUnique();
            builder.HasMany(so => so.SupplyOrdersDetails)
                   .WithOne(so => so.SupplyOrders)
                   .HasForeignKey(p => p.SupplierOrdersId);
        }
    }
}
