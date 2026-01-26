using App.Application.Common.Interface;
using App.Domain.Entitie;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        public readonly ApplicationDbContext _context;
        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Genero>> GetGeneros()
        {
            var generos = await _context.Generos.ToListAsync();
            return generos;
        }

        public async Task<Genero> GetGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            return genero;
        }
    }
}
