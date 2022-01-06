using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Infrastructure.Extensions
{
    public static class PagniationExtension
    {
        public static async Task<PagedResultDTO<T>> GetPagedAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize) where T : class
        {
            var skip = pageIndex * pageSize;
            var groupedQueryResult = (await query.Skip(skip)
                                                 .Take(pageSize)
                                                 .ToListAsync())
                                                 .GroupBy(t => query.Count());
            if (groupedQueryResult.Count() > 0)
            {
                return new PagedResultDTO<T>
                {
                    Items = groupedQueryResult.SelectMany(x => x).ToList(),
                    RowCount = groupedQueryResult.ToList().FirstOrDefault().Key
                };
            }
            else
                return new PagedResultDTO<T>();
        }
    }
}
