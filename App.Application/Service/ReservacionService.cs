using App.Application.Common.Interface.AsientoInterface;
using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Application.Common.Interface.HorarioInterface;
using App.Application.Common.Interface.ReservacionInterface;
using App.Application.Common.ModelsDtos.DtoReservacion;
using App.Domain.Entitie;
using App.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Service
{
    public class ReservacionService : IReservacionService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IHorarioRepository _horarioRepository;
        private readonly IHorarioAsientoRepository _horarioAsientoRepository;
        public ReservacionService(IReservationRepository reservationRepository,
                                  IHorarioRepository horarioRepository,
                                  IHorarioAsientoRepository horarioAsientoRepository
                                   )
        {
            _reservationRepository = reservationRepository;
            _horarioRepository = horarioRepository;
            _horarioAsientoRepository = horarioAsientoRepository;
        }
        public async Task<ResponseRDto> CreateReservacion(CreateReservacionDto dto)
        {
            var userId = "idtemporal";
            var horarioAsiento = await _horarioAsientoRepository
                                    .GetValidacion(dto.IdHorario, dto.IdAsiento);

            if (horarioAsiento == null) throw new BussinessExceptions("No se puede reservar ");
            horarioAsiento.IsReserved = true;

            var newReseracion = new Reservacion
            {
                IdHorario = dto.IdHorario,
                IdAsiento = dto.IdAsiento,
                IdUsuario = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _reservationRepository.CreateReservacion(newReseracion);

            var newReserva = await _reservationRepository.GetReservacionID(newReseracion.ID);

            var response = new ResponseRDto
            {
                IdReservacion = newReserva.ID,
                Horario = newReserva.horario.HoraInicio,
                IdAsiento = newReserva.IdAsiento,
                Usuario = newReserva.IdUsuario,
                Pelicula = newReserva.horario.pelicula.Nombre,
                Sala = newReserva.horario.sala.Nombre,
                estadoReserva = newReserva.estadoReserva,
                CreatedAt = newReserva.CreatedAt
            };
            return response;
        }

        public Task<ResponseRDto> DeleteReservacion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseRDto>> GetReservacion()
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseRDto>> GetReservacionByHorario(int IdHorario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseRDto> GetReservacionID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseRDto> UpdateReservacion(UpdateReservacionDto dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
