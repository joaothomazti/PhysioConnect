using Microsoft.AspNetCore.Mvc;
using Physio.Application.Dtos.Account;
using Physio.Application.Interfaces;

namespace PhysioConnect.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var result = await _accountService.LoginUserAsync(login);

            if (!result.Success)
                return Unauthorized(result.Errors);

            return Ok(result.Data);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            var result = await _accountService.RegisterUserAsync(register);

            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

    }
}
