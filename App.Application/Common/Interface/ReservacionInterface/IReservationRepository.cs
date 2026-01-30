using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface.ReservacionInterface
{
    public interface IReservationRepository
    {
        Task<List<Reservacion>> GetReservacion();
        Task<Reservacion> GetReservacionID(int id);
        Task<Reservacion> CreateReservacion(Reservacion reservacion);
        Task DeleteReservacion(Reservacion reservacion);
        // Task<Reservacion> GetReservacionByUsuario(int IdUsuario);
        Task<List<Reservacion>> GetReservacionByHorario(int IdHorario);

    }
}
