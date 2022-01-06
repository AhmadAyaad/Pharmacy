using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ZPharmacy.API.Extensions;
using ZPharmacy.Core.IServices;
using ZPharmacy.Domain.View;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PharmacyController : ControllerBase
    {
        private readonly IPharamcyService _pharamcyService;

        public PharmacyController(IPharamcyService pharamcyService)
        {
            _pharamcyService = pharamcyService;
        }

        [HttpGet("large-pharmacies")]
        public async Task<IActionResult> GetLargePharmacies()
        {
            try
            {
                var largePharmacies = await _pharamcyService.GetLargePharmacies();
                return Ok(largePharmacies.Data);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving all large pharmacies.");
            }

        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPharmacy(int id)
        //{
        //    var pharmacy = await _pharamcyService.GetPharmacyById(id);
        //    if (pharmacy != null)
        //        return Ok(new Response<Domain.Entities.Pharmacy> { Data = pharmacy, IsSucceeded = true, Error = null });
        //    return NotFound(new Response<Domain.Entities.Pharmacy> { Data = null, IsSucceeded = false, Error = "Not found" });
        //}
        [HttpGet("pharmacyProducts/{pharmacyId}")]
        public async Task<IActionResult> GetPharmacyProducts([FromRoute] int pharmacyId, [FromQuery]PaginationFilter paginationFilter)
        {
            try
            {
                var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
                var pagedResultproductsQuantitiesViewResponse = await _pharamcyService.GetExistingPharmacyProductsAsync(pharmacyId,
                                                                                                                validFilter.PageNumber,
                                                                                                                validFilter.PageSize);
                if (pagedResultproductsQuantitiesViewResponse.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(pagedResultproductsQuantitiesViewResponse);
                return Ok(pagedResultproductsQuantitiesViewResponse.Data);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving pharmacy products.");
            }
        }

        [HttpGet("pharmacyProducts/{pharmacyId}/{productId}")]
        public async Task<IActionResult> GetPharmacyProduct([FromRoute] int pharmacyId, [FromRoute] int productId)
        {
            try
            {
                var productQuantityViewResponse = await _pharamcyService.GetPharmacyProductDetailsAsync(pharmacyId, productId);
                if (productQuantityViewResponse.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(productQuantityViewResponse);
                return Ok(productQuantityViewResponse.Data);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving pharmacy product.");
            }
        }

        //[Route("api/pharmacy/products/{productId}/{pharmacyId}")]
        //[HttpGet]
        //public async Task<IActionResult> GetPharmacyProduct(int productId, int pharmacyId)
        //{
        //    var product = await _pharamcyService.GetPharmacyProduct(productId, pharmacyId);
        //    if (product != null)
        //        return Ok(product.ToList());
        //    return NotFound();
        //}
    }
}