using App.Application.Common.Interface;
using App.Application.Common.ModelsDtos;
using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Service
{
    public class PeliculaService : IPerliculaService
    {

        public Task<List<PeliculaDto>> GetPeliculas()
        {
            throw new NotImplementedException();
        }
    }
}
