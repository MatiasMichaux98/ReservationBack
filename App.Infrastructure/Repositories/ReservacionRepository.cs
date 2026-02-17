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
        public async Task<Reservacion> UpdateReservacion(Reservacion reservacion)
        {
            _context.Reservaciones.Update(reservacion);
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
                .Include(a => a.asiento)
                .ToListAsync();
            return reservacion;
        }
        public async Task<bool> ExistePendiente(int idHorario, int idAsiento)
        {
            var ahora = DateTime.Now;
            var reservacion = await _context.Reservaciones.AnyAsync(r =>
            r.IdHorario == idHorario &&
            r.IdAsiento == idAsiento &&
            r.estadoReserva == Domain.Enums.EstadoReserva.Pendiente &&
            r.ExpiraEn > ahora
            );
            return reservacion;
                
        }
        public async Task<List<Reservacion>> GetReservacionesCanceladas()
        {
            var reservacion = await _context.Reservaciones
                .Include(h => h.horario)
                .ThenInclude(p => p.pelicula)
                .Include(h => h.horario)
                .ThenInclude(a => a.sala)
                .Where(r => r.estadoReserva == Domain.Enums.EstadoReserva.Cancelada)
                .IgnoreQueryFilters()
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
                .IgnoreQueryFilters()
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
                .Include(a => a.asiento)
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.ID == idreservacion);
            return reservacion;
        }

        public async Task<List<Reservacion>> GetReservacionByUsuario(string IdUsuario)
        {
            var reservaciones = await _context.Reservaciones
                .Include(h => h.horario)
                .ThenInclude(p => p.pelicula)
                .Include(h => h.horario)
                .ThenInclude(a => a.sala)
                .Include(a => a.asiento)
               .Where(p => p.IdUsuario == IdUsuario)
               .ToListAsync();
            return reservaciones;
        }
    }
}
