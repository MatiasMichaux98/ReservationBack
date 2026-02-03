using App.Application.Common.ModelsDtos.DtoPelicula;


namespace App.Application.Common.Interface
{
    public interface IPerliculaService
    {
        public Task<List<ResponseDto>> GetPeliculas();
        public Task<List<ResponseDto>> GetPeliculasByGenero(int idGenero);
        public Task<ResponseDto> GetPelicula(int id);
        public Task<ResponseDto> CreatePelicula(CreateMovieDto model);
        public Task<ResponseDto> UpdatePelicula(UpdateMovieDto model ,int id);
        public Task<bool> DeletePelicula(int id);

    }
}
