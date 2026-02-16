using App.Domain.Enums;


namespace App.Application.Common.ModelsDtos.DtoReservacion
{
    public class CreateReservacionDto
    {
        public int IdHorario { get; set; }
        public int IdAsiento { get; set; }
    }
}
