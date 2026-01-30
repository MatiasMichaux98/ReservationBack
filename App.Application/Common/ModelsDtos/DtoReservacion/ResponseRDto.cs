using App.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace App.Application.Common.ModelsDtos.DtoReservacion
{
    public class ResponseRDto
    {
        [Key]
        public int IdReservacion { get; set; }
        public TimeOnly Horario { get; set; }
        public string Pelicula { get; set; }
        public string Sala { get; set; }
        public string Usuario { get; set; }
        public required int IdAsiento { get; set; }
        public EstadoReserva estadoReserva { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
