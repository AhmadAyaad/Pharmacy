using Pharmacy.Domain.View;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IPharamcyService
    {
        IEnumerable<Domain.Entities.Pharmacy> GetParentPharamices();

        Task<IQueryable<ProductQuantityView>> GetPharmacyProducts(int pharmacyId);

        Task<IQueryable<Test>> GetPharmacyProduct(int productId, int pharmacyId);

        Task<Domain.Entities.Pharmacy> GetPharmacyById(int id);
    }
}