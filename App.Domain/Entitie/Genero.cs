
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entitie
{
    public class Genero
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public ICollection<Pelicula> peliculas { get; set; } = new List<Pelicula>();
    }
}
