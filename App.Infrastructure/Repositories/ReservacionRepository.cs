using App.Application.Common.Interface.ReservacionInterface;
using App.Domain.Entitie;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class ReservacionRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Reservacion> CreateReservacion(Reservacion reservacion)
        {
            _context.Reservaciones.Add(reservacion);
            await _context.SaveChangesAsync();
            return reservacion;
        }

        public Task DeleteReservacion(Reservacion reservacion)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservacion>> GetReservacion()
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservacion>> GetReservacionByHorario(int IdHorario)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservacion> GetReservacionID(int idreservacion)
        {
            var reservacion = await _context.Reservaciones
                .Include(h => h.horario)
                .ThenInclude(p => p.pelicula)
                .Include(h => h.horario)
                .ThenInclude(a => a.sala)
                .FirstOrDefaultAsync(p => p.ID == idreservacion);
            return reservacion;
        }

       
    }
}
