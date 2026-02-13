using App.Application.Common.Interface.AuthInterface;
using App.Application.Common.ModelsDtos.DtoAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

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
        private void SaveRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10)
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
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
            SaveRefreshTokenInCookie(result.RefreshToken);
            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {

            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
            {
                SaveRefreshTokenInCookie(response.RefreshToken);
            }
            return Ok(response);
        }
        [HttpPost("revoke-token")]
        public  async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { Message = "Token es requerido " });

            var response = _userService.revokeToken(token);
            if (!response)
            {
                return NotFound(new { messege = "Token no encontrado" });
            }
           
            return Ok(new { message = "Token revoked" });
        }
    }
}
