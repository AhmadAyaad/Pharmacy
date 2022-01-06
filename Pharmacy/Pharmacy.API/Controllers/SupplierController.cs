using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using ZPharmacy.API.Extensions;
using ZPharmacy.Core;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.IServices;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSupplier(SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                var response = await _supplierService.AddNewSupplierAsync(supplierDTO);
                if (response.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(response);
                return this.Created();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while adding new supplier.");
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            try
            {
                var supplierResponseDTOS = await _supplierService.GetSuppliersAsync();
                if (supplierResponseDTOS.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(supplierResponseDTOS);
                return Ok(supplierResponseDTOS.Data);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving all suppliers.");
            }
        }
        [HttpGet("paged-suppliers")]
        public async Task<IActionResult> GetPagedSuppliersAsync([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var suppliersPagedResult = await _supplierService.GetPagedSuppliersAsync(validFilter.PageNumber, validFilter.PageSize);
                return Ok(suppliersPagedResult);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retriving paginated suppliers.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            try
            {
                var supplierDTOResponse = await _supplierService.GetSupplierAsync(id);
                if (supplierDTOResponse.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(supplierDTOResponse);
                return Ok(supplierDTOResponse.Data);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retriving supplier.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)         
        {
            try
            {
                var response = await _supplierService.DeleteSupplierAsync(id);
                if (response.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(response);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while deleting a supplier.");
            }
        }
    }
}
