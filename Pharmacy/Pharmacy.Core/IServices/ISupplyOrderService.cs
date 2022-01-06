using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.IServices
{
    public interface ISupplyOrderService
    {
        Task<Response> ReceiveSupplyOrderAsync(SupplyOrderDTO supplyOrderDTO);
        Task<Response<List<SupplyOrderDTO>>> GetSupplyOrdersAsync();
    }
}
