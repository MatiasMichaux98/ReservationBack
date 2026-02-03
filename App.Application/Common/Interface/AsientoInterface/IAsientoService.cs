using App.Application.Common.ModelsDtos.DtoAsiento;


namespace App.Application.Common.Interface.AsientoInterface
{
    public interface IAsientoService
    {
        public Task<List<asientoResponse>> GetAsientosBySala(int IdSala);
        public Task<AsientoResponseDto> GetAsiento(int idasiento, int idhorario);
        public Task<asientoResponse> GetAsientoID(int id);
    }
}
