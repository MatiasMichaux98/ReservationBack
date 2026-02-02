using App.Application.Common.Interface.HorarioInterface;
using App.Domain.Entitie;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly ApplicationDbContext _context;
        public HorarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Horario> CreateHorario(Horario horario)
        {
             _context.Horarios.Add(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<bool> DeleteHorario(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Horario> GetHorario(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            return horario;
        }

        public async Task<List<Horario>> GetHorarios()
        {
            var horarios = await _context.Horarios.ToListAsync();
            return horarios;
        }

        public async Task<bool> HorarioExiste(int IdSala, DateOnly fecha, TimeOnly hora)
        {
            return await _context.Horarios.AnyAsync(r =>
                           r.IdSala == IdSala &&
                           r.Fecha == fecha &&
                           r.HoraInicio == hora);
        }

        public async Task<Horario> UpdateHorario(Horario horario)
        {
             _context.Horarios.Update(horario);
            await _context.SaveChangesAsync();
            return horario;
        }
    }
}
