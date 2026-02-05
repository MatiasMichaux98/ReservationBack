
using System.ComponentModel.DataAnnotations;


namespace App.Domain.Entitie
{
    public class Pelicula
    {
        [Key]
        public int ID { get; set; }
        public required string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int DuracionMinutos { get; set; }
        public int AñoLanzamiento { get; set; }
         
        public int GeneroID { get; set; }
        public Genero genero { get; set; } = null!;
        public ICollection<Horario> horarios { get; set; } = new List<Horario>();


    }
}
