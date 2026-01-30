using App.Domain.Enums;


namespace App.Application.Common.ModelsDtos.DtoReservacion
{
    public class UpdateReservacionDto
    {
  
        public int IdHorario { get; set; }
        public int IdAsiento { get; set; }
        public string IdUsuario { get; set; }
        public EstadoReserva estadoReserva { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
