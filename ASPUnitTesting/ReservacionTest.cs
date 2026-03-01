
using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Application.Common.Interface.HorarioInterface;
using App.Application.Common.Interface.ReservacionInterface;
using App.Application.Common.ModelsDtos.DtoReservacion;
using App.Application.Service;
using App.Domain.Entitie;
using App.Domain.Entities;
using App.Domain.Enums;
using App.Infrastructure.Exceptions;
using Moq;
using System;

namespace ASPUnitTesting
{
    public class ReservacionTest
    {
        //Arange
        //se configuran los parametros de entrada de nuestra prueba unitaria 
        //Act
        //se ejectura el metodo a probar de nuestra prueba unitaria 
        //Assert
        //se verifican los datos de retorno de nuestra prueba unitaria
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly Mock<IHorarioRepository> _horarioRepositoryMock;
        private readonly Mock<IHorarioAsientoRepository> _horarioAsientoRepositoryMock;
        private readonly ReservacionService _service;
        public ReservacionTest()
        {
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _horarioRepositoryMock = new Mock<IHorarioRepository>();
            _horarioAsientoRepositoryMock = new Mock<IHorarioAsientoRepository>();

            _service = new ReservacionService(
                 _reservationRepositoryMock.Object,
                 _horarioRepositoryMock.Object,
                 _horarioAsientoRepositoryMock.Object
             );

        }
        //CreateReservacion 
        [Fact]
        public async Task Falla_CuandoHorarioIdNoEsEncontrado()
        {
            //Arange
            var dto = new CreateReservacionDto
            {
                IdHorario = 1,
                IdAsientos = new List<int> { 10 }
            };
            _horarioRepositoryMock
                .Setup(r => r.GetHorario(dto.IdHorario))
                .ReturnsAsync((Horario)null);
            //Act + assert
            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
                _service.CreateReservacion(dto, "user-123"));
            Assert.Equal("No existe el horario", exeptions.Message);
        }

        [Theory]
        [InlineData(5)]
        public async Task Falla_cuandoAsientoNoEsvalidoParaHorario(int idAsiento)
        {
            //Arange
            var dto = new CreateReservacionDto
            {
                IdHorario = 1,
                IdAsientos = new List<int> { idAsiento }
            };

            _horarioRepositoryMock
               .Setup(r => r.GetHorario(dto.IdHorario))
               .ReturnsAsync(new Horario { ID = dto.IdHorario });

            _horarioAsientoRepositoryMock
                .Setup(r => r.GetValidacion(dto.IdHorario, idAsiento))
                .ReturnsAsync((HorarioAsiento)null);
            //act
            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
            _service.CreateReservacion(dto, "user-123"));
            //assert
            Assert.Equal($"No se puede reservar el asiento con ID:{idAsiento}",exeptions.Message);
        }

        [Theory]
        [InlineData(3)]
        public async Task Falla_CuandoAsientoTieneReservaPendiente(int IdAsiento)
        {
            //Arange
            var dto = new CreateReservacionDto
            {
                IdHorario = 1,
                IdAsientos = new List<int> { IdAsiento }
            };
            _horarioRepositoryMock
              .Setup(r => r.GetHorario(dto.IdHorario))
              .ReturnsAsync(new Horario { ID = dto.IdHorario });

            _horarioAsientoRepositoryMock
               .Setup(r => r.GetValidacion(dto.IdHorario, IdAsiento))
               .ReturnsAsync(new HorarioAsiento());

            _reservationRepositoryMock
              .Setup(r => r.ExistePendiente(dto.IdHorario, IdAsiento))
              .ReturnsAsync(true);

            //act
            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
            _service.CreateReservacion(dto, "user-123"));
            //assert
            Assert.Equal("El asiento ya tiene una reserva pendiente", exeptions.Message);
        }


        [Theory]
        [InlineData(4)]
        public async Task Falla_Cuandolapeliculayatermino(int IdAsiento)
        {
            var dto = new CreateReservacionDto
            {
                IdHorario = 1,
                IdAsientos = new List<int> { IdAsiento }
            };

            var horarioMock = new Horario
            {
                Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                HoraInicio = new TimeOnly(20,00),
                HoraFinal = new TimeOnly(22,00)
            };
            _horarioRepositoryMock
                .Setup(r => r.GetHorario(dto.IdHorario))
                .ReturnsAsync(horarioMock);

            _horarioAsientoRepositoryMock
               .Setup(r => r.GetValidacion(dto.IdHorario, IdAsiento))
               .ReturnsAsync(new HorarioAsiento());

            _reservationRepositoryMock
            .Setup(r => r.ExistePendiente(dto.IdHorario, IdAsiento))
            .ReturnsAsync(false);
            //act 
            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
            _service.CreateReservacion(dto, "user-123"));
            //Assert
            Assert.Equal("No se puede reservar, la funcion ya termino.", exeptions.Message);

        }
        [Theory]
        [InlineData(4)]
        public async Task Falla_Cuandolapeliculayacomenzo(int IdAsiento)
        {
            var dto = new CreateReservacionDto
            {
                IdHorario = 1,
                IdAsientos = new List<int> { IdAsiento }
            };

            var ahora = DateTime.Now;
            var horarioMock = new Horario
            {
                Fecha = DateOnly.FromDateTime(ahora),
                HoraInicio = TimeOnly.FromDateTime(ahora.AddMinutes(-10)),
                HoraFinal = TimeOnly.FromDateTime(ahora.AddHours(1))
            };
            _horarioRepositoryMock
                .Setup(r => r.GetHorario(dto.IdHorario))
                .ReturnsAsync(horarioMock);

            _horarioAsientoRepositoryMock
               .Setup(r => r.GetValidacion(dto.IdHorario, IdAsiento))
               .ReturnsAsync(new HorarioAsiento());

            _reservationRepositoryMock
            .Setup(r => r.ExistePendiente(dto.IdHorario, IdAsiento))
            .ReturnsAsync(false);
            //act 
            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
            _service.CreateReservacion(dto, "user-123"));
            //Assert
            Assert.Equal("No se puede reservar, la funcion ya comenzo.", exeptions.Message);
        }

        [Fact]
        public async Task Crear_CorrectamenteReservaPelicula()
        {
            var dto = new CreateReservacionDto
            {
                IdHorario = 1,
                IdAsientos = new List<int> { 1, 2 }
            };
            string userId = "user-123";

            var horarioMock = new Horario
            {
                ID = 1,
                Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                HoraInicio = new TimeOnly(15, 0),
                HoraFinal = new TimeOnly(17, 0),
                pelicula = new Pelicula { Nombre = "Batman" },
                sala = new Sala { Nombre = "Sala 1" }
            };
            _horarioRepositoryMock
                .Setup(r => r.GetHorario(dto.IdHorario))
                .ReturnsAsync(horarioMock);
            _horarioAsientoRepositoryMock
               .Setup(r => r.GetValidacion(dto.IdHorario, It.IsAny<int>()))
               .ReturnsAsync(new HorarioAsiento());
            _reservationRepositoryMock
               .Setup(r => r.ExistePendiente(dto.IdHorario, It.IsAny<int>()))
               .ReturnsAsync(false);

            _reservationRepositoryMock
               .Setup(r => r.GetReservacionID(It.IsAny<int>()))
                 .ReturnsAsync(new Reservacion
                 {
                     ID = 500,
                     IdUsuario = userId,
                     horario = horarioMock,
                     estadoReserva = EstadoReserva.Pendiente,
                     ReservaAsientos = new List<ReservaAsiento>
                        {
                            new ReservaAsiento
                            {
                                asientoId = 1,
                                asiento = new Asiento { ID = 1, NumeroAsiento = "A1" }
                            },
                            new ReservaAsiento
                            {
                                asientoId = 2,
                                asiento = new Asiento { ID = 2, NumeroAsiento = "A2" }
                            }
                        }
                 });

            var result = await _service.CreateReservacion(dto, userId);

            Assert.NotNull(result);
            Assert.Equal(500, result.IdReservacion);
            Assert.Equal("Batman", result.Pelicula);
            Assert.Contains(result.asientos, a => a.ID == 1 && a.NumeroAsiento == "A1");
            Assert.Contains(result.asientos, a => a.ID == 2 && a.NumeroAsiento == "A2");

            _reservationRepositoryMock.Verify(
                r => r.CreateReservacion(It.IsAny<Reservacion>()),
                Times.Once
            );

        }

        //ConfirmarReservacion
        [Theory]
        [InlineData(4)]
        public async Task Falla_CuandoLaReservacionNoexiste(int IdReservacion)
        {
            _reservationRepositoryMock
                .Setup(r => r.GetReservacionID(IdReservacion))
                .ReturnsAsync((Reservacion)null);

            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
                _service.ConfirmarReservacion(IdReservacion));
            Assert.Equal("No existe la reservacion", exeptions.Message);
        }

        [Theory]
        [InlineData(4)]
        public async Task Falla_CuandoLaReservacionNoEstaenEstadoPendiente(int IdReservacion)
        {
            _reservationRepositoryMock
                .Setup(r => r.GetReservacionID(IdReservacion))
                .ReturnsAsync(new Reservacion
                {
                    estadoReserva = EstadoReserva.Cancelada
                });

            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
                _service.ConfirmarReservacion(IdReservacion));
            Assert.Equal("No se puede Confirmar", exeptions.Message);
        }

        [Theory]
        [InlineData(4)]
        public async Task Confirmar_CorrectamenteLaReserva(int IdReservacion)
        {
            var horarioMock = new Horario
            {
                ID = 1,
                Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                HoraInicio = new TimeOnly(15, 0),
                HoraFinal = new TimeOnly(17, 0),
                pelicula = new Pelicula { Nombre = "Batman" },
                sala = new Sala { Nombre = "Sala 1" }
            };
            _horarioAsientoRepositoryMock
                .Setup(r => r.GetHorarioAsiento(
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .ReturnsAsync(new HorarioAsiento
                {
                    IsReserved = true
                });
                
            _reservationRepositoryMock
                .Setup(r => r.GetReservacionID(IdReservacion))
               .ReturnsAsync(new Reservacion
               {
                   ID = 4,
                   IdUsuario = "userId-123",
                   IdHorario = 1,
                   horario = horarioMock,
                   estadoReserva = EstadoReserva.Pendiente,
                   ReservaAsientos = new List<ReservaAsiento>
                        {
                            new ReservaAsiento
                            {
                                asientoId = 1,
                                asiento = new Asiento { ID = 1, NumeroAsiento = "A1" }
                            },
                            new ReservaAsiento
                            {
                                asientoId = 2,
                                asiento = new Asiento { ID = 2, NumeroAsiento = "A2" }
                            }
                        }
               
                });

            var result = await _service.ConfirmarReservacion(IdReservacion);

            Assert.NotNull(result);
            Assert.Equal(4, result.IdReservacion);
            Assert.Contains(result.asientos, a => a.ID == 1 && a.NumeroAsiento == "A1");
            Assert.Contains(result.asientos, a => a.ID == 2 && a.NumeroAsiento == "A2");

            _reservationRepositoryMock.Verify(
                r => r.UpdateReservacion(It.IsAny<Reservacion>()),
                Times.Once
            );
        }

        //EliminarReservacion
        [Theory]
        [InlineData(2)]
        public async Task Falla_SilareservacionNoexiste(int IdReservacion)
        {
            _reservationRepositoryMock
               .Setup(r => r.GetReservacionID(IdReservacion))
               .ReturnsAsync((Reservacion)null);

            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
               _service.DeleteReservacion(IdReservacion));
            Assert.Equal("No existe la reservacion", exeptions.Message);
        }
        [Theory]
        [InlineData(2)]
        public async Task Eliminar_ReservacionCorrectamente(int IdReservacion)
        {
            var reservacion = new Reservacion();

            _reservationRepositoryMock
               .Setup(r => r.GetReservacionID(IdReservacion))
               .ReturnsAsync(reservacion);

            _reservationRepositoryMock
                .Setup(r => r.DeleteReservacion(reservacion))
                .ReturnsAsync(true);

            var result = await _service.DeleteReservacion(IdReservacion);

            Assert.NotNull(result);
            Assert.True(result);

            _reservationRepositoryMock.Verify(
                r => r.DeleteReservacion(It.IsAny<Reservacion>()),
                Times.Once
            );

        }

        //GetReservaciones
        [Fact]
        public async void GetFalla_CuandoLasReservacionesNoexisten()
        {
            _reservationRepositoryMock
              .Setup(r => r.GetReservaciones())
              .ReturnsAsync((List<Reservacion>)null);

            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
               _service.GetReservaciones());
            Assert.Equal("No existe las reservaciones", exeptions.Message);
        }

        [Fact]
        public async void Get_ListadeReservaciones()
        {
            var horarioMock = new Horario
            {
                ID = 1,
                Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                HoraInicio = new TimeOnly(15, 0),
                HoraFinal = new TimeOnly(17, 0),
                pelicula = new Pelicula { Nombre = "Batman" },
                sala = new Sala { Nombre = "Sala 1" }
            };
            var reservaciones = new List<Reservacion> { 
                new Reservacion
                {
                    ID = 4,
                   IdUsuario = "userId-123",
                   IdHorario = 1,
                   horario = horarioMock,
                   estadoReserva = EstadoReserva.Pendiente,
                   ReservaAsientos = new List<ReservaAsiento>
                        {
                            new ReservaAsiento
                            {
                                asientoId = 1,
                                asiento = new Asiento { ID = 1, NumeroAsiento = "A1" }
                            },
                            new ReservaAsiento
                            {
                                asientoId = 2,
                                asiento = new Asiento { ID = 2, NumeroAsiento = "A2" }
                            }
                        }
                }
            };
               
            _reservationRepositoryMock
              .Setup(r => r.GetReservaciones())
              .ReturnsAsync(reservaciones);
            var result = await _service.GetReservaciones();
            Assert.NotNull(result);
            Assert.Single(result);
            var reservacion = result.First();
            Assert.Equal(4, reservacion.IdReservacion);
            Assert.Equal(2, reservacion.asientos.Count);
            Assert.Contains(reservacion.asientos, a => a.ID == 1 && a.NumeroAsiento == "A1");
            Assert.Contains(reservacion.asientos, a => a.ID == 2 && a.NumeroAsiento == "A2");
        }


        //GetReservacionID
        [Theory]
        [InlineData(4)]
        public async void GetIdFalla_CuandoReservacionNoexiste(int IdReservacion)
        {
            _reservationRepositoryMock
              .Setup(r => r.GetReservacionID(IdReservacion))
              .ReturnsAsync((Reservacion)null);

            var exeptions = await Assert.ThrowsAsync<BussinessExceptions>(() =>
               _service.GetReservacionID(IdReservacion));
            Assert.Equal("No existe la reservacion", exeptions.Message);
        }
        [Theory]
        [InlineData(4)]
        public async void Get_ListadeReservacionID(int IdReservacion)
        {
            var horarioMock = new Horario
            {
                ID = 1,
                Fecha = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                HoraInicio = new TimeOnly(15, 0),
                HoraFinal = new TimeOnly(17, 0),
                pelicula = new Pelicula { Nombre = "Batman" },
                sala = new Sala { Nombre = "Sala 1" }
            };


            _reservationRepositoryMock
             .Setup(r => r.GetReservacionID(IdReservacion))
             .ReturnsAsync(new Reservacion
             {
                 ID = 4,
                 IdUsuario = "userId-123",
                 IdHorario = 1,
                 horario = horarioMock,
                 estadoReserva = EstadoReserva.Pendiente,
                 ReservaAsientos = new List<ReservaAsiento>
                     {
                            new ReservaAsiento
                            {
                                asientoId = 1,
                                asiento = new Asiento { ID = 1, NumeroAsiento = "A1" }
                            },
                            new ReservaAsiento
                            {
                                asientoId = 2,
                                asiento = new Asiento { ID = 2, NumeroAsiento = "A2" }
                            }
                     }

             });
            

            var result = await _service.GetReservacionID(IdReservacion);
            Assert.NotNull(result);
            Assert.Equal(4, result.IdReservacion);
            Assert.Equal(2, result.asientos.Count);
            Assert.Contains(result.asientos, a => a.ID == 1 && a.NumeroAsiento == "A1");
            Assert.Contains(result.asientos, a => a.ID == 2 && a.NumeroAsiento == "A2");
        }

    }
}