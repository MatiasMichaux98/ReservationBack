using App.Application.Common.Interface;
using App.Application.Common.Interface.AsientoInterface;
using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Application.Common.Interface.HorarioInterface;
using App.Application.Common.Interface.SalaInterface;
using App.Application.Common.ModelsDtos.DtoHorario;
using App.Domain.Entitie;
using App.Infrastructure.Exceptions;
 namespace App.Application.Service
{
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;
        private readonly IPeliculaRepository _peliculaRepository;
        private readonly ISalaRepository _salaRepository;
        private readonly IAsientoRepository _asientoRepository;
        private readonly IHorarioAsientoRepository _horarioAsientoRepository;
        public HorarioService(IHorarioRepository horarioRepository,
                             IPeliculaRepository peliculaRepository,
                             ISalaRepository salaRepository,
                             IAsientoRepository _asientoRepository,
                             IHorarioAsientoRepository horarioAsientoRepository)
        {
            _horarioRepository = horarioRepository;
            _peliculaRepository = peliculaRepository;
            _salaRepository = salaRepository;
            _horarioAsientoRepository = horarioAsientoRepository;
        }
        public async Task<ResponseHorarioDto> CreateHorario(CreateHorarioDto model)
        {
            var pelicula = await _peliculaRepository.GetPelicula(model.IdPelicula);
            if(pelicula == null) throw new BussinessExceptions("No existe la pelicula");

            var sala = await _salaRepository.GetSala(model.IdSala);
            if(sala == null) throw new BussinessExceptions("No existe la sala");

            var horaFinal = model.HoraInicio.AddMinutes(pelicula.DuracionMinutos);

            if (model.Fecha < DateOnly.FromDateTime(DateTime.Today))
                throw new BussinessExceptions("La fecha es invalida"); 

            var newhorario = new Horario
            {
                IdPelicula = model.IdPelicula,
                IdSala = model.IdSala,
                Fecha = model.Fecha,
                HoraInicio = model.HoraInicio,
                HoraFinal = horaFinal
            };
            await _horarioRepository.CreateHorario(newhorario);

            var asientoSala = await _asientoRepository.GetAsientosBySala(model.IdSala);
            if (asientoSala == null || !asientoSala.Any()) throw new Exception("La sala no tiene asientos");
            //creacion de asientos 
            foreach(var asiento in asientoSala)
            {
                await _horarioAsientoRepository.CreateAsync(new HorarioAsiento
                {
                    IdHorario = newhorario.ID,
                    IdAsiento = asiento.ID,
                    IsReserved = false
                });
            }
            return new ResponseHorarioDto
            {
                id = newhorario.ID,
                IdPelicula = newhorario.IdPelicula,
                IdSala = newhorario.IdSala,
                Fecha = newhorario.Fecha,
                HoraInicio = newhorario.HoraInicio,
                HoraFinal = newhorario.HoraFinal
            };
        }

        public async Task<bool> DeleteHorario(int id)
        {
            var horario = await _horarioRepository.GetHorario(id);
            if(horario == null)
            {
                throw new BussinessExceptions("No existe el horario");
            }
            await _horarioRepository.DeleteHorario(horario.ID);
            return true;
        }

        public async Task<ResponseHorarioDto> GetHorario(int id)
        {
            var horario = await _horarioRepository.GetHorario(id);
            if(horario == null)
            {
                throw new BussinessExceptions("El horario no existe");
            }
            return new ResponseHorarioDto
            { 
                id = horario.ID,
                IdPelicula = horario.IdPelicula,
                IdSala = horario.IdSala,
                Fecha = horario.Fecha,
                HoraInicio = horario.HoraInicio,
                HoraFinal = horario.HoraFinal
            };
        }

        public async Task<List<ResponseHorarioDto>> GetHorarios()
        {
            var horarios = await _horarioRepository.GetHorarios();
            if(horarios == null)
            {
                throw new BussinessExceptions("Los horarios no existen");
            }
            return horarios.Select(p => new ResponseHorarioDto
            {
                id = p.ID,
                IdPelicula = p.IdPelicula,
                IdSala = p.IdSala,
                Fecha = p.Fecha,
                HoraInicio = p.HoraInicio,
                HoraFinal = p.HoraFinal
            }).ToList();

        }

        public async Task<ResponseHorarioDto> UpdateHorario(UpdateHorarioDto model, int id)
        {
            var horario = await _horarioRepository.GetHorario(id);
            if (horario == null) throw new BussinessExceptions("EL horario no existe");

            var pelicula = await _peliculaRepository.GetPelicula(model.IdPelicula);
            if (pelicula == null) throw new BussinessExceptions("La pelicula no existe");

            var sala = await _salaRepository.GetSala(model.IdSala);
            if (sala == null) throw new BussinessExceptions("La sala no existe");

            var horaFinal = model.HoraInicio.AddMinutes(pelicula.DuracionMinutos);

            if (model.Fecha < DateOnly.FromDateTime(DateTime.Today))
                throw new BussinessExceptions("Fecha inválida");


            horario.IdPelicula = model.IdPelicula;
            horario.IdSala = model.IdSala;
            horario.Fecha = model.Fecha;
            horario.HoraInicio = model.HoraInicio;
            horario.HoraFinal = horaFinal;

            await _horarioRepository.UpdateHorario(horario);
            return new ResponseHorarioDto
            {
                id = horario.ID,
                IdPelicula = horario.IdPelicula,
                IdSala = horario.IdSala,
                Fecha = horario.Fecha,
                HoraInicio = horario.HoraInicio,
                HoraFinal = horario.HoraFinal
            };
        }
    }
}
