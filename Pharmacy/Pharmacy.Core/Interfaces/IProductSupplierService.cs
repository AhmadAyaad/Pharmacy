using Pharmacy.Core.Dtos;

using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IProductSupplierService
    {
        Task<bool> RecieveProductFromSupplier(CreateProductFromSupplierDto createProductFromSupplierDto);
    }
}
