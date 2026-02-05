using App.Domain.Entitie;

namespace App.Application.Common.Interface.HorarioInterface
{
    public interface IHorarioRepository
    {
        public Task<List<Horario>> GetHorarios();
        public Task<List<Horario>> GetHorariosCancelados();
        public Task<Horario> GetHorario(int id);
        public Task<Horario> CreateHorario(Horario horario);
        public Task<Horario> UpdateHorario(Horario horario);
        public Task<bool> DeleteHorario(int id);
        public Task<bool> HorarioExiste(int IdSala, DateOnly fecha, TimeOnly hora);
    }
}
