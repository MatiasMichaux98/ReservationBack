
using System.ComponentModel.DataAnnotations;


namespace App.Domain.Entitie
{
    public class Horario
    {
        [Key]
        public int ID { get; set; }
        public int IdPelicula { get; set; }
        public Pelicula pelicula { get; set; }
        public int IdSala { get; set; }
        public Sala sala { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFinal { get; set; }
        public ICollection<HorarioAsiento> horarioAsientos { get; set; } = new List<HorarioAsiento>();
        public ICollection<Reservacion> reservaciones { get; set; } = new List<Reservacion>();

    }
}
