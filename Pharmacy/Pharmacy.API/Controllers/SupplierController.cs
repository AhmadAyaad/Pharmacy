using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateSupplier(CreateSupplierDto createSupplierDto)
        {
            if (createSupplierDto != null)
            {
                try
                {
                    var isCreated = await _supplierService.CreateSupplier(createSupplierDto);

                    if (isCreated)
                        return Ok(createSupplierDto);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }
            }
            return BadRequest();

        }


        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await _supplierService.GetSuppliers();
            if (suppliers != null)
                return Ok(suppliers);
            return NotFound();


        }

    }
}
