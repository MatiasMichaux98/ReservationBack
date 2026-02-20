using App.Application.Common.Interface.ReservacionInterface;
using App.Application.Common.ModelsDtos.DtoReservacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        private readonly IReservacionService _reservacionService;
        public ReservacionesController(IReservacionService reservacionService)
        {
            _reservacionService = reservacionService;
        }

        [Authorize(Roles ="User")]
        [HttpPost("CrearReserva")]
        public async Task<IActionResult> CreateReservacion(CreateReservacionDto dto)
        {
            var IdUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(IdUser)) return Unauthorized();

            var reservacion = await _reservacionService.CreateReservacion(dto, IdUser);
            return Ok(reservacion);
        }
        [Authorize(Roles ="User")]
        [HttpPut("ConfirmarReserva/{IdReservacion}")]
        public async Task<IActionResult> ConfirmarReservacion(int IdReservacion)
        {
            var reservacion = await _reservacionService.ConfirmarReservacion(IdReservacion);
            return Ok(reservacion);
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetReservaciones()
        {
            var reservaciones = await _reservacionService.GetReservaciones();
            return Ok(reservaciones);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("reservacionesCanceladas")]
        public async Task<IActionResult> GetReservacionesCanceladas()
        {
            var reservaciones = await _reservacionService.GetReservacionesCanceladas();
            return Ok(reservaciones);
        }
        [Authorize]
        [HttpGet("ByHorario/{id}")]
        public async Task<IActionResult> GetReservacionesByHorario(int id)
        {
            var reservaciones = await _reservacionService.GetReservacionByHorario(id);
            return Ok(reservaciones);
        }
        [Authorize(Roles = "User")]
        [HttpGet("mis-Reservaciones")]
        public async Task<IActionResult> GetReservacionesByUsuario()
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(UserId)) return Unauthorized();

            var reservaciones = await _reservacionService.GetReservacionesByUsuario(UserId);
            return Ok(reservaciones);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("ByUsuario/{id}")]
        public async Task<IActionResult> GetReservacionesByUsuario(string id)
        {
            var reservaciones = await _reservacionService.GetReservacionesByUsuario(id);
            return Ok(reservaciones);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservacionID(int id)
        {
            var reservacion = await _reservacionService.GetReservacionID(id);
            return Ok(reservacion);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            var reservacion = await _reservacionService.DeleteReservacion(id);
            return Ok(reservacion);
        }
    }
}
