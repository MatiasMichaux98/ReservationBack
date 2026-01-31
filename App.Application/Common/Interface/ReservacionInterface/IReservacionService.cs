using App.Application.Common.ModelsDtos.DtoReservacion;


namespace App.Application.Common.Interface.ReservacionInterface
{
    public interface IReservacionService
    {
        Task<List<ResponseRDto>> GetReservaciones();
        Task<ResponseRDto> GetReservacionID(int id);
        Task<ResponseRDto> CreateReservacion(CreateReservacionDto dto);
        Task<ResponseRDto> UpdateReservacion(UpdateReservacionDto dto, int id);
        Task<bool> DeleteReservacion(int id);
        Task<List<ResponseRDto>> GetReservacionByHorario(int IdHorario);

    }
}
