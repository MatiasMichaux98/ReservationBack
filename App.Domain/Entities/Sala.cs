
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entitie
{
    public class Sala
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public ICollection<Horario> horarios { get; set; } = new List<Horario>();
        public ICollection<Asiento> asientos { get; set; } = new List<Asiento>();
    }
}
