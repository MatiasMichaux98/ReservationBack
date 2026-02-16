using App.Application.Common.ModelsDtos.DtoReservacion;


namespace App.Application.Common.Interface.ReservacionInterface
{
    public interface IReservacionService
    {
        Task<List<ResponseRDto>> GetReservaciones();
        Task<List<ReservaCanceladaDto>> GetReservacionesCanceladas();
        Task<ResponseRDto> GetReservacionID(int id);
        Task<ResponseRDto> CreateReservacion(CreateReservacionDto dto, string IdUser);
        Task<ResponseRDto> ConfirmarReservacion(int IdReservacion);
        Task<bool> DeleteReservacion(int id);
        Task<List<ResponseRDto>> GetReservacionByHorario(int IdHorario);

    }
}
