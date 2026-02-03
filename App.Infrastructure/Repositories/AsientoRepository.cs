using App.Application.Common.Interface.AsientoInterface;
using App.Domain.Entitie;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructure.Repositories
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly ApplicationDbContext _context;
        public AsientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Asiento> GetAsiento(int idasiento)
        {
            var asiento = await _context.Asientos.FindAsync(idasiento);
            return asiento;
        }

        public async Task<List<Asiento>> GetAsientosBySala(int IdSala)
        {
            var asientos = await _context.Asientos
                .Where(p => p.IdSala == IdSala)
                .ToListAsync();
            return asientos;
        }
    }
}
