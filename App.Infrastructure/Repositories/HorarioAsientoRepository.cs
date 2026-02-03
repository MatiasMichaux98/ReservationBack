using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Domain.Entitie;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructure.Repositories
{
    public class HorarioAsientoRepository : IHorarioAsientoRepository
    {
        private readonly ApplicationDbContext _context;
        public HorarioAsientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<HorarioAsiento> GetAsiento(int idasiento, int idHorario)
        {
            var asiento = await _context.HorarioAsientos
                .Include(a => a.asiento)
                .Where(a => a.IdAsiento == idasiento && a.IdHorario == idHorario)
                .FirstOrDefaultAsync();
            return asiento;

        }

        public async Task<HorarioAsiento> CreateAsync(HorarioAsiento horarioAsiento)
        {
            _context.HorarioAsientos.Add(horarioAsiento);
            await _context.SaveChangesAsync();
            return horarioAsiento;
        }

        public async Task<HorarioAsiento> GetValidacion(int horarioId, int AsientoId)
        {
            var asientohorario = await _context.HorarioAsientos
                .SingleOrDefaultAsync(s => s.IdHorario == horarioId
                                        && s.IdAsiento == AsientoId
                                        && !s.IsReserved);

            return asientohorario;
        }
    }
}
