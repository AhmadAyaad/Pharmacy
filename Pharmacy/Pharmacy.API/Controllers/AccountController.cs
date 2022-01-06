using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZPharmacy.API.Extensions;
using ZPharmacy.Identity.DTOS;
using ZPharmacy.Identity.IServices;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(ReigsterUserDTO reigsterUserDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            var response = await _accountService.RegisterUserAsync(reigsterUserDTO);
            if (response.Status != ResponseStatus.Succeeded)
                return this.FailedResponseResult(response);
            return this.Created();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            var userDTOResponse = await _accountService.LoginAsync(loginDTO);
            if (userDTOResponse.Status != ResponseStatus.Succeeded)
                return this.FailedResponseResult(userDTOResponse);
            return Ok(userDTOResponse.Data);
        }
    }
}
