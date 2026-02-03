using App.Application.Common.Interface.GeneroInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;
        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var generos = await _generoService.GetGeneros();
            return Ok(generos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenero(int id)
        {
            var genero = await _generoService.GetGenero(id);
            return Ok(genero);
        }
    }
}
