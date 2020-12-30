using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        [HttpPost]
        public async Task<IActionResult> CreateSupplier(CreateSupplierDto createSupplierDto)
        {
            if (createSupplierDto != null)
            {
                try
                {
                    var supplier = new Supplier
                    {
                        Address = createSupplierDto.Address,
                        Phone = createSupplierDto.Phone,
                        SupplierName = createSupplierDto.SupplierName
                    };
                    var isCreated = await _supplierService.CreateSupplier(supplier);

                    if (isCreated)
                        return Ok(supplier);
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
