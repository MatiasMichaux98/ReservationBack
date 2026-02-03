using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entitie
{
    public class Asiento
    {
        [Key]
        public int ID { get; set; }
        public string NumeroAsiento { get; set; }
        public int IdSala { get; set; }
        public Sala sala { get; set; }
        public  ICollection<HorarioAsiento>HorarioAsientos { get; set; } = new List<HorarioAsiento>();
        public ICollection<Reservacion> reservaciones { get; set; } = new List<Reservacion>();

    }
}
