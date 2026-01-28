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
        Task<HorarioAsiento> GetValidacion(int horarioId, int AsientoId);
        Task<HorarioAsiento> CreateAsync(HorarioAsiento horarioAsiento);
    }
}
