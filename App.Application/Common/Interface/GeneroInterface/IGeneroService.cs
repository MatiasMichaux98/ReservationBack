using App.Application.Common.ModelsDtos.DtoGenero;
using App.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface.GeneroInterface
{
    public  interface IGeneroService
    {
        public Task<List<GeneroResponseDto>> GetGeneros();
        public Task<GeneroResponseDto> GetGenero(int id);

    }
}
