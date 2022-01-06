using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using ZPharmacy.API.Extensions;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.IServices;

namespace ZPharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyOrderController : ControllerBase
    {
        private readonly ISupplyOrderService _supplyOrderService;

        public SupplyOrderController(ISupplyOrderService supplyOrderService)
        {
            _supplyOrderService = supplyOrderService;
        }
        [HttpPost("supply-products")]
        public async Task<IActionResult> RecieveProductsFromSupplier(SupplyOrderDTO supplyOrderDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            try
            {
                await _supplyOrderService.ReceiveSupplyOrderAsync(supplyOrderDTO);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while recieve products from supplier.");
            }
        }
        [HttpGet("supply-orders-details")]
        public async Task<IActionResult> GetSupplyOrders()
        {
            try
            {
                var supplyOrdersResponse = await _supplyOrderService.GetSupplyOrdersAsync();
                if (supplyOrdersResponse.Status != Shared.Models.ResponseStatus.Succeeded)
                    return this.FailedResponseResult(supplyOrdersResponse);
                return Ok(supplyOrdersResponse.Data);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving supply orders.");
            }   
        }
    }
}
