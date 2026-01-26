using App.Domain.Entitie;
using Microsoft.AspNetCore.Http;


namespace App.Application.Common.ModelsDtos.DtoPelicula
{
    public class CreateMovieDto
    {
        public required string Nombre { get; set; }
        public string Descripcion { get; set; }
        public IFormFile? Imagen { get; set; }
        public int DuracionMinutos { get; set; }
        public int AñoLanzamiento { get; set; }
        public int GeneroID { get; set; }
     
    }
}
