using System.Collections.Generic;
namespace ZPharmacy.Shared.Models
{
    public class PagedResultDTO<T> where T : class
    {
        public IList<T> Items { get; set; }
        public long RowCount { get; set; }
        public PagedResultDTO()
        {
            Items = new List<T>();
        }
    }
}
