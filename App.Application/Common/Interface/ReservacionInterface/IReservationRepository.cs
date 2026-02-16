using App.Domain.Entitie;


namespace App.Application.Common.Interface.ReservacionInterface
{
    public interface IReservationRepository
    {
        Task<List<Reservacion>> GetReservaciones();
        Task<List<Reservacion>> GetReservacionesCanceladas();
        Task<Reservacion> GetReservacionID(int id);
        Task<Reservacion> CreateReservacion(Reservacion reservacion);
        Task<Reservacion> UpdateReservacion(Reservacion reservacion);
        Task<bool> DeleteReservacion(Reservacion reservacion);
        // Task<Reservacion> GetReservacionByUsuario(int IdUsuario);
        Task<List<Reservacion>> GetReservacionByHorario(int IdHorario);
        Task<bool> ExistePendiente(int idHorario, int idAsiento);


    }
}
