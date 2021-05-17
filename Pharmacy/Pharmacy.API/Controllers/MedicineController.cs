using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Pharmacy.API.Util;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Core.Mapper;
using Pharmacy.Core.Pagniation;
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
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IUnitService _unitService;
        private readonly IHostingEnvironment _environment;
        private readonly UploadFileUtil _uploadFileUtil;
        private List<MedicneFileUploadDto> _list;
        private readonly MedicineMapper _medicineMapper;
        private readonly ILogger<MedicineController> _logger;
        List<Medicine> _medicinesList;

        public MedicineController(IMedicineService medicineService,
                                  IUnitService unitService,
                                  IHostingEnvironment environment,
                                  UploadFileUtil uploadFileUtil,
                                  MedicineMapper medicineMapper,
                                  ILogger<MedicineController> logger)
        {
            _medicineService = medicineService;
            _unitService = unitService;
            _environment = environment;
            _uploadFileUtil = uploadFileUtil;
            _list = new List<MedicneFileUploadDto>();
            _medicineMapper = medicineMapper;
            _logger = logger;
            _medicinesList = new List<Medicine>();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine(CreateMedicineDto createMedicineDto)
        {

            if (createMedicineDto != null)
            {
                try
                {
                    var isCreated = await _medicineService.CreateMedicine(createMedicineDto);
                    if (isCreated)
                        return Ok(new Response<CreateMedicineDto>(createMedicineDto) { IsSucceeded = true, Error = null });
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }

            }
            return BadRequest(new Response<CreateMedicineDto>() { Data = null, IsSucceeded = false, Error = "Object cannot be null" });
        }


        [HttpPost("upload")]
        public async Task<IActionResult> CreateMedicines([FromForm] IFormFile form)
        {
            _uploadFileUtil.CreateFile(_environment, form);
            _list = await _uploadFileUtil.ReadFileAsync(form, _list);
            _medicinesList = _medicineMapper.MapToMedicines(_list.Skip(1).ToList());
            if (_medicinesList != null)
                return Ok(new Response<List<Medicine>> { Data = _medicinesList, IsSucceeded = true, Error = null });
            return BadRequest(new Response<List<Medicine>>
            {
                Data = null,
                IsSucceeded = false,
                Message = "check file format or make sure it contains data"
            });
        }
        [HttpPost("addToDb")]
        public async Task<IActionResult> AddMedicinesToDb(List<Medicine> medicines)
        {
            try
            {
                if (medicines != null)
                {
                    await _medicineService.AddRangOfMedicines(medicines);
                    return Ok(new Response<List<Medicine>> { Data = medicines, IsSucceeded = true, Error = null });
                }
                return BadRequest(new Response<List<Medicine>> { Data = null, IsSucceeded = false, Error = "Medicines List cannot be null" });
            }
            catch (Exception e)
            {
                return BadRequest(new Response<List<Medicine>> { Data = null, IsSucceeded = false, Error = e.Message });

            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicines([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var medicines = await _medicineService.GetMedicines(validFilter);
            if (medicines != null)
                return Ok(medicines);
            return NotFound();
        }
        [HttpGet("units")]
        public async Task<IActionResult> GetMedicinesWithUnitNames()
        {
            var medicines = await _medicineService.GetMedicinesWithUnitNames();
            if (medicines != null)
                return Ok(new Response<List<Medicine>> { Data = medicines, Error = null, IsSucceeded = true });
            return NotFound(new Response<List<Medicine>> { Data = null, IsSucceeded = false, Error = "Not Found" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var medicine = await _medicineService.GetMedicine(id);
            if (medicine != null)
                return Ok(new Response<Medicine> { Data = medicine, Error = null, IsSucceeded = true });
            return NotFound(new Response<Medicine> { Data = null, IsSucceeded = false, Error = "Not Found" });
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please send a valid medicine id");
            try
            {
                await _medicineService.DeleteMedicine(id);
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
