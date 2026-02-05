using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Application.Common.Interface.HorarioInterface;
using App.Application.Common.Interface.ReservacionInterface;
using App.Application.Common.ModelsDtos.DtoReservacion;
using App.Domain.Entitie;
using App.Domain.Enums;
using App.Infrastructure.Exceptions;

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

            var horario = await _horarioRepository.GetHorario(dto.IdHorario);
            if (horario == null) throw new BussinessExceptions("No existe el horario");

            var horarioAsiento = await _horarioAsientoRepository
                                    .GetValidacion(dto.IdHorario, dto.IdAsiento);
            if (horarioAsiento == null) throw new BussinessExceptions($"No se puede reservar el asiento con ID:{dto.IdAsiento}");
            
            if (DateTime.Now >= horario.Fecha.ToDateTime(horario.HoraInicio)) 
                throw new BussinessExceptions("No se puede reservar la funcion ya comenzo");
            

            horarioAsiento.IsReserved = true;

            var newReseracion = new Reservacion
            {
                IdHorario = dto.IdHorario,
                IdAsiento = dto.IdAsiento,
                IdUsuario = userId,
                estadoReserva = EstadoReserva.Reservada,
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
                estadoReserva = newReserva.estadoReserva.ToString(),
                CreatedAt = newReserva.CreatedAt
            };
            return response;
        }

        public async Task<bool> DeleteReservacion(int id)
        {
            var reservacion = await _reservationRepository.GetReservacionID(id);
            if (reservacion == null) throw new BussinessExceptions("No existe la reservacion");

            await _reservationRepository.DeleteReservacion(reservacion);
            return true;
        }
        public async Task<List<ResponseRDto>> GetReservaciones()
        {
            var reservaciones = await _reservationRepository.GetReservaciones();
            if (reservaciones == null) throw new BussinessExceptions("No existe las reservaciones");

            return reservaciones.Select(r => new ResponseRDto
            {
                IdReservacion = r.ID,
                Horario = r.horario.HoraInicio,
                IdAsiento = r.IdAsiento,
                Usuario = r.IdUsuario,
                Pelicula = r.horario?.pelicula?.Nombre,
                Sala = r.horario?.sala?.Nombre,
                estadoReserva = r.estadoReserva.ToString(),
                CreatedAt = r.CreatedAt

            }).ToList();
        }
        public async Task<List<ResponseRDto>> GetReservacionesCanceladas()
        {
            var reservaciones = await _reservationRepository.GetReservacionesCanceladas();
            if (reservaciones == null) throw new BussinessExceptions("No existe las reservaciones");

            return reservaciones.Select(r => new ResponseRDto
            {
                IdReservacion = r.ID,
                Horario = r.horario.HoraInicio,
                IdAsiento = r.IdAsiento,
                Usuario = r.IdUsuario,
                Pelicula = r.horario?.pelicula?.Nombre,
                Sala = r.horario?.sala?.Nombre,
                estadoReserva = r.estadoReserva.ToString(),
                CreatedAt = r.CreatedAt

            }).ToList();
        }
        public async Task<List<ResponseRDto>> GetReservacionByHorario(int IdHorario)
        {
            var reservacion = await _reservationRepository.GetReservacionByHorario(IdHorario);
            if (reservacion == null) throw new BussinessExceptions("No existe las reservaciones");

            return reservacion.Select(r => new ResponseRDto
            {
                IdReservacion = r.ID,
                Horario = r.horario.HoraInicio,
                IdAsiento = r.IdAsiento,
                Usuario = r.IdUsuario,
                Pelicula = r.horario.pelicula.Nombre,
                Sala = r.horario.sala.Nombre,
                estadoReserva = r.estadoReserva.ToString(),
                CreatedAt = r.CreatedAt
            }).ToList();

        }

        public async Task<ResponseRDto> GetReservacionID(int id)
        {
            var reservacion = await _reservationRepository.GetReservacionID(id);
            if (reservacion == null) throw new BussinessExceptions("No existe la reservacion");

            return new ResponseRDto
            {
                IdReservacion = reservacion.ID,
                Horario = reservacion.horario.HoraInicio,
                IdAsiento = reservacion.IdAsiento,
                Usuario = reservacion.IdUsuario,
                Pelicula = reservacion.horario.pelicula.Nombre,
                Sala = reservacion.horario.sala.Nombre,
                estadoReserva = reservacion.estadoReserva.ToString(),
                CreatedAt = reservacion.CreatedAt
            };
        }

        public Task<ResponseRDto> UpdateReservacion(UpdateReservacionDto dto, int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
