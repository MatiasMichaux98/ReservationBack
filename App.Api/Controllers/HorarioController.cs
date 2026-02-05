using App.Application.Common.Interface;
using App.Application.Common.ModelsDtos.DtoHorario;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        public readonly IHorarioService _horarioService;
        public HorarioController(IHorarioService horarioService)
        {
            _horarioService = horarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHorarios()
        {
            var horarios = await _horarioService.GetHorarios();
            return Ok(horarios);
        }
        [HttpGet("HorariosCancelados")]
        public async Task<IActionResult> GetHorariosCancelados()
        {
            var horarios = await _horarioService.GetHorariosCancelados();
            return Ok(horarios);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHorarioID(int id)
        {
            var horario = await _horarioService.GetHorario(id);
            return Ok(horario);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHorarios(CreateHorarioDto model)
        {
            var horario = await _horarioService.CreateHorario(model);
            return Ok(horario);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHorario( UpdateHorarioDto model, int id)
        {
            var horario = await _horarioService.UpdateHorario(model, id);
            return Ok(horario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorario(int id)
        {
            var horario = await _horarioService.DeleteHorario(id);
            return Ok(horario);
        }

    }
}
