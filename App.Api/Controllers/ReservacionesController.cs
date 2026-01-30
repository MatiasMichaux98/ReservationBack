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
    }
}
