using FLuentAPI.Models;
using FLuentAPI.Services.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLuentAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginRequest loginRequest)
        {
            var token = await _authService.Login(loginRequest);
            return Ok(token);
        }
    }
}
