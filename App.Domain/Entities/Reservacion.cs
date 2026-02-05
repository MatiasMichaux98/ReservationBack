using App.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace App.Domain.Entitie
{
    public class Reservacion
    {
        [Key]
        public int ID { get; set; }
        public int? IdHorario { get; set; }
        public Horario? horario { get; set; }
        public int IdAsiento { get; set; }
        public Asiento asiento { get; set; }
        public string IdUsuario { get; set; }
        public string? CanceladaPor { get; set; }
        public DateTime? FechaCancelacionUtc { get; set;}
        public EstadoReserva estadoReserva { get; set;  }
        public DateTime CreatedAt { get; set; }

    }
}
