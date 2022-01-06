//using Microsoft.AspNetCore.Mvc;

//using Pharmacy.Core.Dtos;
//using Pharmacy.Core.Interfaces;

//using System;
//using System.Diagnostics;
//using System.Threading.Tasks;

//namespace Pharmacy.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductSupplierController : ControllerBase
//    {
//        private readonly IProductSupplierService _productSupplierService;

//        public ProductSupplierController(IProductSupplierService productSupplierService)
//        {
//            _productSupplierService = productSupplierService;
//        }

//        [HttpPost("create")]
//        public async Task<IActionResult> Create(CreateProductFromSupplierDto createProductFromSupplierDto)
//        {
//            try
//            {
//                var isCreated = await _productSupplierService.RecieveProductFromSupplier(createProductFromSupplierDto);
//                if (isCreated)
//                    return Ok(201);
//            }
//            catch (Exception e)
//            {
//                Trace.WriteLine(e.Message);
//            }
//            return BadRequest();
//        }
//    }
//}
