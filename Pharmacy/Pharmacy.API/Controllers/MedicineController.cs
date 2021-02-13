using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Pharmacy.API.Util;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Core.Mapper;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
                        return Ok(createMedicineDto);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }

            }
            return BadRequest();
        }


        [HttpPost("upload")]
        public async Task<IActionResult> CreateMedicines([FromForm] IFormFile form)
        {
            _uploadFileUtil.CreateFile(_environment, form);
            _list = await _uploadFileUtil.ReadFileAsync(form, _list);
            _medicinesList = _medicineMapper.MapToMedicines(_list.Skip(1).ToList());

            //try
            //{
            //    var isCreated = await _medicineService.AddRangOfMedicines(_medicinesList);
            //    if (isCreated)
            //        return Ok();
            //}
            //catch (Exception e)
            //{
            //    Trace.WriteLine(e.Message);
            //}
            return Ok(_medicinesList);

            //return BadRequest("Error in file formatting");
        }
        [HttpPost("addToDb")]
        public async Task<IActionResult> AddMedicinesToDb(List<Medicine> medicines)
        {
            await _medicineService.AddRangOfMedicines(medicines);
            return Ok(medicines);
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicines()
        {
            _logger.LogInformation("Info logging");
            var medicines = await _medicineService.GetMedicines();
            if (medicines != null)
                return Ok(medicines);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var medicine = await _medicineService.GetMedicine(id);
            if (medicine != null)
                return Ok(medicine);
            return NotFound();
        }
    }
}
