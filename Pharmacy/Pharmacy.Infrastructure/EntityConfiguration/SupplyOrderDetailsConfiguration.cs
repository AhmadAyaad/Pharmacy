using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Infrastructure.EntityConfiguration
{
    public class SupplyOrderDetailsConfiguration : IEntityTypeConfiguration<SupplyOrderDetails>
    {
        public void Configure(EntityTypeBuilder<SupplyOrderDetails> builder)
        {
            builder.HasIndex(sod => sod.Id);
            builder.HasIndex(sod => sod.ApprovalNumber).IsUnique();
            builder.HasIndex(sod => sod.SupplyOrderNumber).IsUnique();
        }
    }
}
