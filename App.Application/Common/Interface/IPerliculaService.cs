using App.Application.Common.ModelsDtos.DtoPelicula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface
{
    public interface IPerliculaService
    {
        public Task<List<ResponseDto>> GetPeliculas();
        public Task<ResponseDto> GetPelicula(int id);
        public Task<ResponseDto> CreatePelicula(CreateMovieDto model);
        public Task<ResponseDto> UpdatePelicula(UpdateMovieDto model ,int id);
        public Task<bool> DeletePelicula(int id);

    }
}
