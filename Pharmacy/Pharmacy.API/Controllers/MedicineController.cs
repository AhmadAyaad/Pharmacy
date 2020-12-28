using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Dtos;
using Pharmacy.Core.Interfaces;
using Pharmacy.Domain.Entities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IUnitService _unitService;

        public MedicineController(IMedicineService medicineService, IUnitService unitService)
        {
            _medicineService = medicineService;
            _unitService = unitService;
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
