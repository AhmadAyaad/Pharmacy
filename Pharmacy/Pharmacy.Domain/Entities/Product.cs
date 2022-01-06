using ZPharmacy.Domain.Enums;

namespace ZPharmacy.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string LocalCode { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public decimal? SellingPrice { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Medicine;

    }
}