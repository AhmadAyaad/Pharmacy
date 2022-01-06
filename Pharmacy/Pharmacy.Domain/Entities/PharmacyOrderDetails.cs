//using System;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ZPharmacy.Domain.Entities
//{
//    public class PharmacyOrderDetails : BaseEntity
//    {
//        public int Id { get; set; }
//        public int ProductId { get; set; }
//        public virtual Product Product { get; set; }

//        //[Column("pharmacy_Recviver_Id")]
//        public int RecviverPharmacyId { get; set; }
//        public virtual Pharmacy ReciverPharmacy { get; set; }
//        public int Quantity { get; set; }
//        public decimal Price { get; set; }
//        public DateTime ExpireDate { get; set; }
//        public int PharmacyOrderDetailsId { get; set; }
//        public virtual PharmacyOrders PharmacyOrders { get; set; }
//    }
//}