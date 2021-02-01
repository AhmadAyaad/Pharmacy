using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSupplierController : ControllerBase
    {
        readonly IProductImportDetailsService _productImportDetailsService;
        readonly ISupplierMedicinePharamcyService _supplierMedicinePharamcyService;
        private readonly IUnitOfWork _unitOfWork;

        public ProductSupplierController(IProductImportDetailsService productImportDetailsService,
                                ISupplierMedicinePharamcyService supplierMedicinePharamcyService,
                                IUnitOfWork unitOfWork)
        {
            _productImportDetailsService = productImportDetailsService;
            _supplierMedicinePharamcyService = supplierMedicinePharamcyService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductFromSupplierDto createProductFromSupplierDto)
        {
            try
            {


           await  _productImportDetailsService.CreateProductImport(createProductFromSupplierDto);
            await _supplierMedicinePharamcyService.CreateNewProductTransfer(createProductFromSupplierDto);
            await _unitOfWork.SaveChangesAsync();
                return Ok(201);
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return BadRequest();



        }
    }
}
