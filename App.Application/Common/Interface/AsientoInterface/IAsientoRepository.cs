using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface.AsientoInterface
{
    public interface IAsientoRepository
    {
        public Task<List<Asiento>> GetAsientosBySala(int IdSala);
        
    }
}
