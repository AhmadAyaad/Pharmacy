using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitsController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUnits()
        {
            var units = await _unitService.GetUnits();
            if (units != null)
                return Ok(units);
            return NotFound();
        }
        [HttpGet("bla/{name}")]
        public async Task<IActionResult> GetBla(string name)
        {
            return Ok(await _unitService.GetUnitIdByName(name));
        }

    }

}
