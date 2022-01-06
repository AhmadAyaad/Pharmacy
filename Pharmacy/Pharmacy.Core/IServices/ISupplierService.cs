using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.IServices
{
    public interface ISupplierService
    {
        Task<Response> AddNewSupplierAsync(SupplierDTO supplierDTO);
        Task<Response<List<SupplierDTO>>> GetSuppliersAsync();
        Task<PagedResultDTO<SupplierDTO>> GetPagedSuppliersAsync(int pageIndex, int pageSize);
        Task<Response<SupplierDTO>> GetSupplierAsync(int supplierId);
        Task<Response> UpdateSupplierAsync(SupplierDTO supplierDTO);
        Task<Response> DeleteSupplierAsync(int supplierId);
    }
}
