using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ZPharmacy.API.Extensions;
using ZPharmacy.Core;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.IServices;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        //private readonly IUnitService _unitService;
        private readonly IHostingEnvironment _environment;
        //private readonly UploadFileUtil _uploadFileUtil;
        private List<MedicneFileUploadDto> _list;
        private readonly ILogger<ProductController> _logger;
        List<Product> _medicinesList;

        public ProductController(IProductService productService,
                                  //IUnitService unitService,
                                  IHostingEnvironment environment,
                                  //UploadFileUtil uploadFileUtil,
                                  ILogger<ProductController> logger)
        {
            _productService = productService;
            //_unitService = unitService;
            _environment = environment;
            //_uploadFileUtil = uploadFileUtil;
            _list = new List<MedicneFileUploadDto>();
            _logger = logger;
            _medicinesList = new List<Product>();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                var response = await _productService.AddNewProductAsync(productDTO);
                if (response.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(response);
                return this.Created();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong while adding new product");
            }

        }
        [HttpGet("paginated-products")]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedResultproductDTO = await _productService.GetPaginatedProductsAsync(validFilter);
                return Ok(pagedResultproductDTO);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving all products.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var productsDTOSResponse = await _productService.GetProductsAsync();
                return Ok(productsDTOSResponse.Data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving all products.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please send a valid medicine id");
            try
            {
                var response = await _productService.DeleteProductAsync(id);
                if (response.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(response);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while deleting product.");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var productRepsonse = await _productService.GetProductAsync(id);
                if (productRepsonse.Status != ResponseStatus.Succeeded)
                    return this.FailedResponseResult(productRepsonse);
                return Ok(productRepsonse.Data);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while getting product.");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            var response = await _productService.UpdateProductAsync(productDTO);
            if (response.Status != ResponseStatus.Succeeded)
                return this.FailedResponseResult(response);
            return NoContent();
        }


        //[HttpPost("upload")]
        //public async Task<IActionResult> CreateMedicines([FromForm] IFormFile form)
        //{
        //    _uploadFileUtil.CreateFile(_environment, form);
        //    _list = await _uploadFileUtil.ReadFileAsync(form, _list);
        //    _medicinesList = _medicineMapper.MapToMedicines(_list.Skip(1).ToList());
        //    if (_medicinesList != null)
        //        return Ok(new Response<List<Product>> { Data = _medicinesList, IsSucceeded = true, Error = null });
        //    return BadRequest(new Response<List<Product>>
        //    {
        //        Data = null,
        //        IsSucceeded = false,
        //        Message = "check file format or make sure it contains data"
        //    });
        //}
        //[HttpPost("addToDb")]
        //public async Task<IActionResult> AddProducts(List<ProductViewModel> products)
        //{
        //    try
        //    {
        //        if (products != null)
        //        {
        //            await _productService.AddRangeAsync(products);
        //            return Ok(new Response<List<Product>> { Data = products, IsSucceeded = true, Error = null });
        //        }
        //        return BadRequest(new Response<List<Product>> { Data = null, IsSucceeded = false, Error = "Medicines List cannot be null" });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new Response<List<Product>> { Data = null, IsSucceeded = false, Error = e.Message });

        //    }
        //}

        [HttpGet("products-with-unit")]
        public async Task<IActionResult> GetProductsWithUnitNames()
        {
            try
            {
                var productWithUnitNamesDTOSResponse = await _productService.GetProductsWithUnitNames();
                return Ok(productWithUnitNamesDTOSResponse.Data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retrieving all products with their unit name.");
            }
        }
        [HttpPost("signalr")]
        public IActionResult TestSignalR(object data)
        {
            _productService.sendProductNotification(data);
            return Ok();
        }
    }
}
