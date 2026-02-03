using App.Domain.Entitie;


namespace App.Application.Common.Interface
{
    public interface IPeliculaRepository
    {
        public Task<List<Pelicula>> GetPeliculas();
        public Task<List<Pelicula>> GetPeliculaByGenero(int idGenero);
        public Task<Pelicula> GetPelicula(int id);
        public Task<Pelicula> CreatePelicula(Pelicula pelicula);
        public Task<Pelicula> UpdatePelicula(Pelicula pelicula);
        public Task<bool> DeletePelicula(int id);

    }
}
