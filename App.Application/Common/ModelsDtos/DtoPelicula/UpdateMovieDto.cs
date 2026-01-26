using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace App.Application.Common.ModelsDtos.DtoPelicula
{
    public class UpdateMovieDto
    {
     
        public required string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public IFormFile? Imagen { get; set; }
        public int? DuracionMinutos { get; set; }
        public int? AñoLanzamiento { get; set; }
        public int? GeneroID { get; set; }
     
    }
}
