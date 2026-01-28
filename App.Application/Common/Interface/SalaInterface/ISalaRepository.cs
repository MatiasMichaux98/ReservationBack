using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface.SalaInterface
{
    public interface ISalaRepository
    {
        public Task<List<Sala>> GetSalas();
        public Task<Sala> GetSala(int id);
       
    }
}
