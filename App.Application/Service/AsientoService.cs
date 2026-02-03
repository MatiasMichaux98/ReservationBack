using App.Application.Common.Interface.AsientoInterface;
using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Application.Common.Interface.HorarioInterface;
using App.Application.Common.ModelsDtos.DtoAsiento;
using App.Domain.Entitie;
using App.Infrastructure.Exceptions;

namespace App.Application.Service
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;
        private readonly IHorarioRepository _horarioRepository;
        private readonly IHorarioAsientoRepository _horarioAsientoRepository;

        public AsientoService(IAsientoRepository asientoRepository,
                              IHorarioAsientoRepository horarioAsientoRepository,
                              IHorarioRepository horarioRepository)
        {
            _asientoRepository = asientoRepository;
            _horarioRepository = horarioRepository;
            _horarioAsientoRepository = horarioAsientoRepository;
        }
        public async Task<AsientoResponseDto> GetAsiento(int idasiento , int idhorario)
        {
            var asiento = await _horarioAsientoRepository.GetAsiento(idasiento, idhorario);
            if (asiento == null) throw new BussinessExceptions("No existe el asiento");

            return new AsientoResponseDto
            {
                IdAsiento = asiento.ID,
                Numero = asiento.asiento.NumeroAsiento,
                IsReserved = asiento.IsReserved
            };
        }

        public async Task<asientoResponse> GetAsientoID(int id)
        {
            var asiento = await _asientoRepository.GetAsiento(id);
            if(asiento == null) throw new BussinessExceptions("No existe el asiento");
            return new asientoResponse
            {
                ID = asiento.ID,
                NumeroAsiento = asiento.NumeroAsiento
            };
        }

        public async Task<List<asientoResponse>> GetAsientosBySala(int IdSala)
        {
            var asientos = await _asientoRepository.GetAsientosBySala(IdSala);
            if (asientos == null) throw new BussinessExceptions("No existe los asientos");

            return asientos.Select(a => new asientoResponse
            {
                ID = a.ID,
                NumeroAsiento = a.NumeroAsiento
            }).ToList();
        }
    }
}
