namespace ZPharmacy.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
    }
}