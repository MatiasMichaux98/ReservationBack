using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface.HorarioAsientoInterface
{
    public interface IHorarioAsientoRepository
    {
        public Task<HorarioAsiento> GetAsiento(int idasiento, int idHorario);
        public Task<HorarioAsiento> GetValidacion(int horarioId, int AsientoId);
        public  Task<HorarioAsiento> CreateAsync(HorarioAsiento horarioAsiento);
    }
}
