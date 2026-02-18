using App.Application.Common.Interface.AsientoInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoService _asientoService;
        public AsientoController(IAsientoService asientoService)
        {
            _asientoService = asientoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetasientoID(int id)
        {
            var asiento = await _asientoService.GetAsientoID(id);
            return Ok(asiento);
        }

        [HttpGet("{idasiento}/horario{idhorario}")]
        public async Task<IActionResult> GetAsiento(int idasiento, int idhorario)
        {
            var asiento = await _asientoService.GetAsiento(idasiento, idhorario);
            return Ok(asiento);
        }

        [HttpGet("bySala/{id}")]
        public async Task<IActionResult> GetasientoBysala(int id)
        {
            var asiento = await _asientoService.GetAsientosBySala(id);
            return Ok(asiento);
        }

    }
}
