using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Interfaces;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{

    [ApiController]
    public class PharmacyController : ControllerBase
    {
        readonly IPharamcyService _pharamcyService;

        public PharmacyController(IPharamcyService pharamcyService)
        {
            _pharamcyService = pharamcyService;
        }

        [Route("api/largePharmacies")]
        [HttpGet]
        public Task<IActionResult> GetLargePharamcies()
        {
            var largePharmacies = _pharamcyService.GetParentPharamices();
            if (largePharmacies != null)
                return Task.Run<IActionResult>(() => Ok(largePharmacies));
            return Task.Run<IActionResult>(() => NotFound());
        }

        [HttpGet("api/pharmacyProducts")]
        public async Task<IActionResult> GetPharmacyProducts([FromQuery(Name ="name")]string pharmacyName)
        {
            var pharmacyProducts = await _pharamcyService.GetPharmacy(pharmacyName:pharmacyName);
            if (pharmacyProducts != null)
                return Ok(pharmacyProducts);
            return NotFound();
        }

    }
}
