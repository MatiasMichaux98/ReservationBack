using App.Application.Common.Interface.SalaInterface;
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
    public class SalaRepository : ISalaRepository
    {
        private readonly ApplicationDbContext _context;
        public SalaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Sala> GetSala(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            return sala;

        }

        public async Task<List<Sala>> GetSalas()
        {
            var salas = await _context.Salas.ToListAsync();
            return salas;
        }
    }
}
