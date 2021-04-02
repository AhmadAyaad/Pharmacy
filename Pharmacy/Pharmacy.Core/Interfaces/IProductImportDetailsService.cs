using Pharmacy.Core.Dtos;

using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IProductImportDetailsService
    {
        Task<bool> CreateProductImport(CreateProductFromSupplierDto createProductFromSupplierDto);
    }
}
