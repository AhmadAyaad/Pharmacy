using System.Collections.Generic;

namespace Pharmacy.Domain.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? Phone { get; set; }
        public ICollection<PatientTransaction> PatientTransactions { get; set; }
                                                      = new HashSet<PatientTransaction>();
    }
}
