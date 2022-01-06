//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using ZPharmacy.Domain.Entities;

//namespace ZPharmacy.Infrastructure.EntityConfiguration
//{
//    internal class PharmacyOrdersConfiguration : IEntityTypeConfiguration<PharmacyOrderDetails>
//    {
//        public void Configure(EntityTypeBuilder<PharmacyOrderDetails> builder)
//        {
//            builder.HasKey(ipod => ipod.Id);
//            builder.HasMany(b => b.PharmacyOrders)
//                   .WithOne(ipod => ipod.PharmacyOrderDetails)
//                   .HasForeignKey(p => p.PharmacyOrderDetailsId);
//        }
//    }
//}
