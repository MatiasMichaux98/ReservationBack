using App.Application.Common.Interface.ReservacionInterface;
using App.Domain.Entitie;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


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

        public async Task<bool> DeleteReservacion(Reservacion reservacion)
        {
            _context.Reservaciones.Remove(reservacion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Reservacion>> GetReservaciones()
        {
            var reservacion = await _context.Reservaciones
                .Include(h => h.horario)
                .ThenInclude(p => p.pelicula)
                .Include(h => h.horario)
                .ThenInclude(a => a.sala)
                .ToListAsync();
            return reservacion;
        }

        public async Task<List<Reservacion>> GetReservacionByHorario(int IdHorario)
        {
            var reservacion = await _context.Reservaciones
                .Include(h => h.horario)
                .ThenInclude(p => p.pelicula)
                .Include(h => h.horario)
                .ThenInclude(a => a.sala)
                .Where(p => p.IdHorario == IdHorario)
                .ToListAsync();
            return reservacion;
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
