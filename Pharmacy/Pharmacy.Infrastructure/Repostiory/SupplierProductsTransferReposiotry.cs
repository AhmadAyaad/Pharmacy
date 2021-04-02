using Pharmacy.Domain.Entities;
using Pharmacy.Infrastructure.Data;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public class SupplierProductsTransferReposiotry : Repository<SupplierProductsTransfer>, ISupplierProductsTransferReposiotry
    {
        public SupplierProductsTransferReposiotry(PharmacyDbContext context) : base(context)
        {

        }
        public async Task<bool> AddRangeAsync(List<SupplierProductsTransfer> supplierProductsTransfers)
        {
            try
            {

                if (supplierProductsTransfers.Count > 0)
                {
                    await _context.SupplierProductsTransfers.AddRangeAsync(supplierProductsTransfers);
                    return true;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return false;
        }
    }
}
