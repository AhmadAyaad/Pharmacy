using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Infrastructure.EntityConfiguration
{
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(u => u.UnitName).IsRequired().HasMaxLength(50);
            builder.HasData(new Unit {Id=1, UnitName = "قرص" }, new Unit { Id = 2, UnitName = "فيال" }, new Unit { Id = 3, UnitName = "زجاجة" });
        }
    }
}
