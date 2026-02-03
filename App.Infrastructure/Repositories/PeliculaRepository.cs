using App.Application.Common.Interface;
using App.Domain.Entitie;
using App.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly ApplicationDbContext _context;
        public PeliculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Pelicula> CreatePelicula(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
            return pelicula;
        }

        public async Task<bool> DeletePelicula(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            _context.Peliculas.Remove(pelicula);
            return true;
        }

        public async Task<Pelicula> GetPelicula(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            return pelicula;
        }

        public async Task<List<Pelicula>> GetPeliculaByGenero(int idGenero)
        {
            var peliculas = await _context.Peliculas
                .Where(g => g.GeneroID == idGenero)
                .ToListAsync();
            return peliculas;
        }

        public async Task<List<Pelicula>> GetPeliculas()
        {
            var peliculas = await _context.Peliculas.ToListAsync();
            return peliculas;
        }

        public async Task<Pelicula> UpdatePelicula(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();
            return pelicula;

        }
    }
}
