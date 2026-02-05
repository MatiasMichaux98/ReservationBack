using App.Application.Common.Interface.ReservacionInterface;
using App.Application.Common.ModelsDtos.DtoReservacion;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreateReservacion(CreateReservacionDto dto)
        {
            var reservacion = await _reservacionService.CreateReservacion(dto);
            return Ok(reservacion);
        }
        [HttpGet]
        public async Task<IActionResult> GetReservaciones()
        {
            var reservaciones = await _reservacionService.GetReservaciones();
            return Ok(reservaciones);
        }
        [HttpGet("reservacionesCanceladas")]
        public async Task<IActionResult> GetReservacionesCanceladas()
        {
            var reservaciones = await _reservacionService.GetReservacionesCanceladas();
            return Ok(reservaciones);
        }
        [HttpGet("/ByHorario/{id}")]
        public async Task<IActionResult> GetReservacionesByHorario(int id)
        {
            var reservaciones = await _reservacionService.GetReservacionByHorario(id);
            return Ok(reservaciones);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservacionID(int id)
        {
            var reservacion = await _reservacionService.GetReservacionID(id);
            return Ok(reservacion);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            var reservacion = await _reservacionService.DeleteReservacion(id);
            return Ok(reservacion);
        }
    }
}
