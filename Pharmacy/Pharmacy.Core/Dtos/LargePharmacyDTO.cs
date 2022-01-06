namespace ZPharmacy.Core.Dtos
{
    public class LargePharmacyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ISEligibleToSellToPatients { get; set; } = false;

    }
}
