using System.Collections.Generic;

namespace ZPharmacy.Domain.Entities
{
    public class SupplyOrders : BaseEntity
    {
        public int Id { get; set; }
        public int ImportOrderNumber { get; set; }
        public virtual ICollection<SupplyOrderDetails> SupplyOrdersDetails { get; set; }
    }
}