using App.Application.Common.ModelsDtos.DtoAsiento;
using App.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace App.Application.Common.ModelsDtos.DtoReservacion
{
    public class ResponseRDto
    {
        public int IdReservacion { get; set; }
        public TimeOnly Horario { get; set; }
        public string Pelicula { get; set; }
        public string Sala { get; set; }
        public string Usuario { get; set; }
        public List<asientoResponse> asientos { get; set; }
        public string estadoReserva { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
