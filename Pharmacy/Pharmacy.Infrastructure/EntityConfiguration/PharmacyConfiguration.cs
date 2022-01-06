using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZPharmacy.Infrastructure.EntityConfiguration
{
    internal class PharmacyConfiguration : IEntityTypeConfiguration<Domain.Entities.Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Pharmacy> builder)
        {
            //self relation
            builder.HasOne(ph => ph.ParentPharmacy)
                   .WithMany(ph => ph.ChildrenPharmacies)
                   .HasForeignKey(ph => ph.ParentPharmacyId);
            builder.Property(ph => ph.Name)
                   .IsRequired().HasMaxLength(50);
            builder.HasData(new Domain.Entities.Pharmacy() {Id=1, Name = "مجانى", ISEligibleToSellToPatients = false, PharmacyType = Domain.Enums.PharmacyTypeEnum.Large },
                new Domain.Entities.Pharmacy() {Id=2, Name = "تأمين", ISEligibleToSellToPatients = false, PharmacyType = Domain.Enums.PharmacyTypeEnum.Large },
                new Domain.Entities.Pharmacy() {Id=3, Name = "نفقة", ISEligibleToSellToPatients = true, PharmacyType = Domain.Enums.PharmacyTypeEnum.Large });
        }
    }
}
