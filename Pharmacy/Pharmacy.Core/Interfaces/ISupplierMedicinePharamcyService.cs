using Pharmacy.Core.Dtos;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface ISupplierMedicinePharamcyService
    {
        Task<bool> CreateNewProductTransfer(CreateProductFromSupplierDto createProductFromSupplierDto);
    }
}
