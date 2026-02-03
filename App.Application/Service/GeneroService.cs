using App.Application.Common.Interface;
using App.Application.Common.Interface.GeneroInterface;
using App.Application.Common.ModelsDtos.DtoGenero;

using App.Infrastructure.Exceptions;

namespace App.Application.Service
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        public async Task<GeneroResponseDto> GetGenero(int id)
        {
            var genero = await _generoRepository.GetGenero(id);
            if (genero == null) throw new BussinessExceptions("no existe el genero");
            return new GeneroResponseDto
            {
                idGenero = genero.ID,
                Nombre = genero.Nombre
            };
        }

        public async Task<List<GeneroResponseDto>> GetGeneros()
        {
            var genero = await _generoRepository.GetGeneros();
            if (genero == null) throw new BussinessExceptions("no existe el genero");

            return genero.Select(g => new GeneroResponseDto
            {
                idGenero = g.ID,
                Nombre = g.Nombre
            }).ToList();
        }
    }
}
