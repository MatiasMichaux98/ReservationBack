using App.Domain.Entitie;


namespace App.Application.Common.Interface
{
    public interface IGeneroRepository
    {
        public Task<List<Genero>> GetGeneros();
        public Task<Genero> GetGenero(int id);

    }
}
