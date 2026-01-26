using App.Application.Common.Interface;
using App.Application.Common.ModelsDtos.DtoPelicula;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPerliculaService _perliculaService;
        public PeliculaController(IPerliculaService perliculaService)
        {
            _perliculaService = perliculaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeliculas()
        {
            var peliculas = await _perliculaService.GetPeliculas();
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeliculaID(int id)
        {
            var peliculas = await _perliculaService.GetPelicula(id);
            return Ok(peliculas);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreatePeliculas([FromForm] CreateMovieDto model)
        {
            var pelicula = await _perliculaService.CreatePelicula(model);
            return Ok(pelicula);
        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdatePelicula([FromForm] UpdateMovieDto model ,int id )
        {
            var pelicula = await _perliculaService.UpdatePelicula(model ,id);
            return Ok(pelicula);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePeliculas(int id)
        {
            var peliculas = await _perliculaService.DeletePelicula(id);
            return Ok(peliculas);
        }
    }
}
