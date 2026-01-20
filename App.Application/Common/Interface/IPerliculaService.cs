using App.Application.Common.ModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface
{
    internal interface IPerliculaService
    {
        public Task<List<PeliculaDto>> GetPeliculas();

    }
}
