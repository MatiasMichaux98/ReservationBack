using App.Application.Common.Interface;
using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        public Task<Pelicula> GetPelicula()
        {
            throw new NotImplementedException();
        }
    }
}
