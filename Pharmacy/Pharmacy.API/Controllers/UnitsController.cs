using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZPharmacy.Core;
using ZPharmacy.Core.IServices;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.API.Controllers
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
            try
            {
                var unitsDTOSReponse = await _unitService.GetUnits();
                if (unitsDTOSReponse.Status == ResponseStatus.NotFound)
                    return NotFound();
                return Ok(unitsDTOSReponse.Data);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong while retrieving all product units");
            }
        }
    }
}