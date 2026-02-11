using App.Application.Common.Interface.AuthInterface;
using App.Application.Common.ModelsDtos.DtoAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSecuredData()
        {
            return Ok("La informacion es solo para usuarios autenticados");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _userService.LoginAsync(model);
            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {

            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }
    }
}
