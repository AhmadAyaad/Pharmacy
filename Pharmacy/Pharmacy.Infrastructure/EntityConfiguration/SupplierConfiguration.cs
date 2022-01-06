using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Infrastructure.EntityConfiguration
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(s => s.Address).IsRequired().HasMaxLength(75);
            builder.HasIndex(s => s.Name).IsUnique();
            builder.HasIndex(s => s.Phone).IsUnique();
        }
    }
}
