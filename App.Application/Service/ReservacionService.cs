using App.Application.Common.Interface.AsientoInterface;
using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Application.Common.Interface.HorarioInterface;
using App.Application.Common.Interface.ReservacionInterface;
using App.Application.Common.ModelsDtos.DtoAsiento;
using App.Application.Common.ModelsDtos.DtoReservacion;
using App.Domain.Entitie;
using App.Domain.Entities;
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
        public async Task<ResponseRDto> CreateReservacion(CreateReservacionDto dto, string IdUser)
        {

            var horario = await _horarioRepository.GetHorario(dto.IdHorario);
            if (horario == null) throw new BussinessExceptions("No existe el horario");

            foreach(var asientosid in dto.IdAsientos)
            {
                var horarioAsiento = await _horarioAsientoRepository.GetValidacion(dto.IdHorario, asientosid);
                if (horarioAsiento == null) throw new BussinessExceptions($"No se puede reservar el asiento con ID:{asientosid}");
                
                var existePendiente = await _reservationRepository.ExistePendiente(dto.IdHorario, asientosid);
                if (existePendiente) throw new BussinessExceptions("El asiento ya tiene una reserva pendiente");
            }
            
            var fechaAhora = DateTime.Now;
            var horaInicio = horario.Fecha.ToDateTime(horario.HoraInicio);
            var horaFinal = horario.Fecha.ToDateTime(horario.HoraFinal);

            if(horaFinal <= horaInicio)
            {
                horaFinal = horaFinal.AddDays(1);
            }
            if (fechaAhora >= horaFinal) 
                throw new BussinessExceptions("No se puede reservar, la funcion ya termino.");

            else if  (fechaAhora >= horaInicio) 
                throw new BussinessExceptions("No se puede reservar, la funcion ya comenzo.");

            var ahora = DateTime.Now;
            var newReseracion = new Reservacion
            {
                IdHorario = dto.IdHorario,
                IdUsuario = IdUser,
                estadoReserva = EstadoReserva.Pendiente,
                CreatedAt = ahora,
                ExpiraEn = ahora.AddMinutes(1)
            };

            foreach(var asientos in dto.IdAsientos)
            {
                newReseracion.ReservaAsientos.Add(new ReservaAsiento
                {
                    asientoId = asientos,
                });
            }

            await _reservationRepository.CreateReservacion(newReseracion);

            var newReserva = await _reservationRepository.GetReservacionID(newReseracion.ID);

            var response = new ResponseRDto
            {
                IdReservacion = newReserva.ID,
                Horario = newReserva.horario.HoraInicio,
                Usuario = newReserva.IdUsuario,
                Pelicula = newReserva.horario.pelicula.Nombre,
                Sala = newReserva.horario.sala.Nombre,
                estadoReserva = newReserva.estadoReserva.ToString(),
                CreatedAt = newReserva.CreatedAt,
                asientos = newReserva.ReservaAsientos.Select(r => new asientoResponse
                {
                    ID = r.asiento.ID,
                    NumeroAsiento = r.asiento.NumeroAsiento
                }).ToList()
            };
            return response;
        }
        public async Task<ResponseRDto> ConfirmarReservacion(int IdReservacion)
        {
            
            var reservacion = await _reservationRepository.GetReservacionID(IdReservacion);
            if (reservacion == null) throw new BussinessExceptions("No existe la reservacion");

            if (reservacion.estadoReserva != EstadoReserva.Pendiente)
                throw new BussinessExceptions("No se puede Confirmar");

            foreach(var idasientos in reservacion.ReservaAsientos)
            {
                var horarioasiento = await _horarioAsientoRepository.GetHorarioAsiento(reservacion.IdHorario.Value,idasientos.asientoId);
                if (horarioasiento == null) throw new BussinessExceptions("No existe el asiento para este horario");
                horarioasiento.IsReserved = true;
            }
            reservacion.estadoReserva = EstadoReserva.Reservada;

            await _reservationRepository.UpdateReservacion(reservacion);
            return new ResponseRDto
            {
                IdReservacion = reservacion.ID,
                Horario = reservacion.horario.HoraInicio,
                Usuario = reservacion.IdUsuario,
                Pelicula = reservacion.horario.pelicula.Nombre,
                Sala = reservacion.horario.sala.Nombre,
                estadoReserva = reservacion.estadoReserva.ToString(),
                CreatedAt = reservacion.CreatedAt,
                asientos = reservacion.ReservaAsientos.Select(r => new asientoResponse
                {
                    ID = r.asiento.ID,
                    NumeroAsiento = r.asiento.NumeroAsiento
                }).ToList()
            };
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
                asientos = r.ReservaAsientos.Select(r => new asientoResponse
                {
                    ID = r.asiento.ID,
                    NumeroAsiento = r.asiento.NumeroAsiento
                }).ToList(),
                Usuario = r.IdUsuario,
                Pelicula = r.horario.pelicula.Nombre,
                Sala = r.horario.sala.Nombre,
                estadoReserva = r.estadoReserva.ToString(),
                CreatedAt = r.CreatedAt

            }).ToList();
        }
        public async Task<List<ReservaCanceladaDto>> GetReservacionesCanceladas()
        {
            var reservaciones = await _reservationRepository.GetReservacionesCanceladas();
            if (reservaciones == null) throw new BussinessExceptions("No existe las reservaciones");

            return reservaciones.Select(r => new ReservaCanceladaDto
            {
                IdReservacion = r.ID,
                Horario = r.horario.HoraInicio,
                asientos = r.ReservaAsientos.Select(r => new asientoResponse
                {
                    ID = r.asiento.ID,
                    NumeroAsiento = r.asiento.NumeroAsiento
                }).ToList(),
                Usuario = r.IdUsuario,
                Pelicula = r.horario.pelicula.Nombre,
                Sala = r.horario.sala.Nombre,
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
                asientos = r.ReservaAsientos.Select(r => new asientoResponse
                {
                    ID = r.asiento.ID,
                    NumeroAsiento = r.asiento.NumeroAsiento
                }).ToList(),
                Usuario = r.IdUsuario,
                Pelicula = r.horario.pelicula.Nombre,
                Sala = r.horario.sala.Nombre,
                estadoReserva = r.estadoReserva.ToString(),
                CreatedAt = r.CreatedAt
            }).ToList();

        }
        public async Task<List<ResponseRDto>> GetReservacionesByUsuario(string IdUsuario)
        {
            var reservaciones = await _reservationRepository.GetReservacionByUsuario(IdUsuario);
            if (reservaciones == null) throw new BussinessExceptions("No existe las reservaciones");
            return reservaciones.Select(r => new ResponseRDto
            {
                IdReservacion = r.ID,
                Horario = r.horario.HoraInicio,
                asientos = r.ReservaAsientos.Select(r => new asientoResponse
                {
                    ID = r.asiento.ID,
                    NumeroAsiento = r.asiento.NumeroAsiento
                }).ToList(),
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
                asientos = reservacion.ReservaAsientos.Select(r => new asientoResponse
                {
                    ID = r.asiento.ID,
                    NumeroAsiento = r.asiento.NumeroAsiento
                }).ToList(),
                Usuario = reservacion.IdUsuario,
                Pelicula = reservacion.horario.pelicula.Nombre,
                Sala = reservacion.horario.sala.Nombre,
                estadoReserva = reservacion.estadoReserva.ToString(),
                CreatedAt = reservacion.CreatedAt
            };
        }

        
    }
}
