using App.Application.Common.ModelsDtos.DtoAsiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.ModelsDtos.DtoReservacion
{
    public class ReservaCanceladaDto
    {
        public int IdReservacion { get; set; }
        public TimeOnly Horario { get; set; }
        public string Pelicula { get; set; }
        public string Sala { get; set; }
        public string Usuario { get; set; }
        public List<asientoResponse> asientos { get; set; }
        public string estadoReserva { get; set; }
        public string? CanceladaPor { get; set; }
        public DateTime? FechaCancelacionUtc { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
