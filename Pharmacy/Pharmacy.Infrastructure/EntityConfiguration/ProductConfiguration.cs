using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Infrastructure.EntityConfiguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(p => p.LocalCode).IsRequired().HasMaxLength(10);
            builder.Property(p => p.NationalCode).IsRequired().HasMaxLength(10);
            builder.HasIndex(m => m.Name);
            builder.HasIndex(p => p.LocalCode).IsUnique();
            builder.HasIndex(p => p.NationalCode).IsUnique();
        }
    }
}
