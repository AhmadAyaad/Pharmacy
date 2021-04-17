using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.View;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharamcyService _pharamcyService;

        public PharmacyController(IPharamcyService pharamcyService)
        {
            _pharamcyService = pharamcyService;
        }

        [Route("api/largePharmacies")]
        [HttpGet]
        public Task<IActionResult> GetLargePharamcies()
        {
            var largePharmacies = _pharamcyService.GetParentPharamices();
            if (largePharmacies != null)
                return Task.Run<IActionResult>(() => Ok(largePharmacies));
            return Task.Run<IActionResult>(() => NotFound());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPharmacy(int id)
        {
            var pharmacy = await _pharamcyService.GetPharmacyById(id);
            if (pharmacy != null)
                return Ok(new Response<Pharmacy.Domain.Entities.Pharmacy> { Data = pharmacy, IsSucceeded = true, Error = null });
            return NotFound(new Response<Pharmacy.Domain.Entities.Pharmacy> { Data = null, IsSucceeded = false, Error = "Not found" });
        }

        [Route("api/pharmacyProducts/{pharmacyId}")]
        [HttpGet]
        public async Task<IActionResult> GetPharmacyProducts([FromRoute] int pharmacyId)
        {
            try
            {
                var productQuantities = await _pharamcyService
                                        .GetPharmacyProducts(pharmacyId);
                if (productQuantities.Count() > 0)
                    return Ok(new Response<List<ProductQuantityView>>
                    {
                        Data = productQuantities.ToList(),
                        IsSucceeded = true,
                        Error = null
                    });
                return BadRequest(new Response<List<ProductQuantityView>>
                {
                    Data = null,
                    IsSucceeded = false,
                    Error = null
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response<List<ProductQuantityView>>
                    {
                        Data = null,
                        IsSucceeded = false,
                        Error = e.Message
                    });
            }
        }

        [Route("api/pharmacy/products/{productId}/{pharmacyId}")]
        [HttpGet]
        public async Task<IActionResult> GetPharmacyProduct(int productId, int pharmacyId)
        {
            var product = await _pharamcyService.GetPharmacyProduct(productId, pharmacyId);
            if (product != null)
                return Ok(product.ToList());
            return NotFound();
        }
    }
}