using App.Application.Common.ModelsDtos.DtoHorario;


namespace App.Application.Common.Interface
{
    public interface IHorarioService
    {
        public Task<List<ResponseHorarioDto>> GetHorarios();
        public Task<ResponseHorarioDto> GetHorario(int id);
        public Task<ResponseHorarioDto> CreateHorario(CreateHorarioDto model);
        public Task<ResponseHorarioDto> UpdateHorario(UpdateHorarioDto model, int id);
        public Task<bool> DeleteHorario(int id);
    }
}
