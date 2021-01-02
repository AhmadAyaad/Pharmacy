using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Pharmacy.Core.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IHostingEnvironment _environment;

        public MedicineController(IMedicineService medicineService, IHostingEnvironment environment)
        {
            _medicineService = medicineService;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine(CreateMedicineDto createMedicineDto)
        {

            if (createMedicineDto != null)
            {
                try
                {
                    var medicine = new Medicine
                    {
                        MedicineCode = createMedicineDto.MedicineCode,
                        MedicineName = createMedicineDto.MedicineName,
                        SellingPrice = createMedicineDto.SellingPrice,
                        ExpireDate = createMedicineDto.ExpireDate,
                        UnitId = createMedicineDto.UnitId
                    };

                    var isCreated = await _medicineService.CreateMedicine(medicine);

                    if (isCreated)
                        return Ok(medicine);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }

            }
            return BadRequest();
        }


        [HttpPost("upload")]
        public IActionResult CreateMedicines([FromForm] IFormFile form)
        {

            string fileName = $"{_environment.ContentRootPath}\\{form.FileName}";

            using (var filestram = System.IO.File.Create(fileName))
            {
                form.CopyTo(filestram);
                filestram.Flush();
            }
            List<Medicine> list = new List<Medicine>();
            var fn = $"{Directory.GetCurrentDirectory()}\\{form.FileName}";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fn, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        list.Add(new Medicine()
                        {
                            MedicineName = reader.GetValue(1) != null ? reader.GetValue(1).ToString() : ""
                        }); ;
                    }

                }
            }
            return Ok(list);
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicines()
        {
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
