using Pharmacy.Domain.View;

using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Interfaces
{
    public interface IPharmacyRepository
    {
        Task<IQueryable<ProductQuantityView>> GetPharmacyProducts(int pharmacyId);

        Task<IQueryable<ProductDetailQuantityView>> GetPharmacyProduct(int productId, int pharmacyId);
    }
}