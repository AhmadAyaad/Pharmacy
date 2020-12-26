using Microsoft.AspNetCore.Mvc;
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

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicine(Medicine medicine)
        {
            try
            {
                var isCreated = await _medicineService.CreateMedicine(medicine);
                if (isCreated)
                {
                    return Ok(medicine);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            return BadRequest();
        }
    }
}
