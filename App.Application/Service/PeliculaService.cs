using App.Application.Common.Interface;
using App.Application.Common.ModelsDtos.DtoPelicula;
using App.Domain.Entitie;

namespace App.Application.Service
{
    public class PeliculaService : IPerliculaService
    {
        private readonly IPeliculaRepository _peliculaRepository;
        private readonly IGeneroRepository _generoRepository;
        public PeliculaService(IPeliculaRepository peliculaRepository,
            IGeneroRepository generoRepository)
        {
            _peliculaRepository = peliculaRepository;
            _generoRepository = generoRepository;
        }

        public async Task<ResponseDto> CreatePelicula(CreateMovieDto model)
        {
            if(model.Imagen == null || model.Imagen.Length == 0)
            {
                throw new Exception("No se encontro la imagen");
            }
            var rutaCarpetaImg = Path.Combine("wwwroot", "img");
            var rutaimg = Path.Combine(rutaCarpetaImg, model.Imagen.FileName);

            if (!Directory.Exists(rutaCarpetaImg))
            {
                Directory.CreateDirectory(rutaCarpetaImg);
            }
            using(var stream = new FileStream(rutaimg, FileMode.Create))
            {
                await model.Imagen.CopyToAsync(stream);
            }

            var genero = await _generoRepository.GetGenero(model.GeneroID);
            if(genero == null)
            {
                throw new Exception("No se encontro el genero");
            }

            var pelicula = new Pelicula
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                DuracionMinutos = model.DuracionMinutos,
                Imagen = "/img/" + model.Imagen.FileName,
                AñoLanzamiento = model.AñoLanzamiento,
                GeneroID = genero.ID
            };
            await _peliculaRepository.CreatePelicula(pelicula);
            return new ResponseDto
            {
                ID = pelicula.ID,
                Nombre = pelicula.Nombre,
                Descripcion = pelicula.Descripcion,
                Imagen = pelicula.Imagen,
                DuracionMinutos = pelicula.DuracionMinutos,
                AñoLanzamiento = pelicula.AñoLanzamiento,
                GeneroID = pelicula.GeneroID
            };
        }

        public async Task<bool> DeletePelicula(int id)
        {
            var pelicula = await _peliculaRepository.GetPelicula(id);
            if(pelicula == null)
            {
                throw new Exception("Pelicula no encontrada");
            }
            await _peliculaRepository.DeletePelicula(pelicula.ID);
            
            return true;
        }

        public async Task<ResponseDto> GetPelicula(int id)
        {
            var pelicula = await _peliculaRepository.GetPelicula(id);
            if(pelicula == null)
            {
                throw new Exception("Pelicula no encontrada");
            }
            return new ResponseDto
            {
                ID = pelicula.ID,
                Nombre = pelicula.Nombre,
                Descripcion = pelicula.Descripcion,
                Imagen = pelicula.Imagen,
                DuracionMinutos = pelicula.DuracionMinutos,
                AñoLanzamiento = pelicula.AñoLanzamiento,
                GeneroID = pelicula.GeneroID
            };
        }

        public async Task<List<ResponseDto>> GetPeliculas()
        {
            var peliculas = await _peliculaRepository.GetPeliculas();
            if (!peliculas.Any())
            {
                return new List<ResponseDto>();
            }
            return peliculas.Select(p => new ResponseDto
            {
                ID = p.ID,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Imagen = p.Imagen,
                DuracionMinutos = p.DuracionMinutos,
                AñoLanzamiento = p.AñoLanzamiento,
                GeneroID = p.GeneroID
            }).ToList();
        }

        public async Task<ResponseDto> UpdatePelicula(UpdateMovieDto model, int id)
        {
            var movie = await _peliculaRepository.GetPelicula(id);
            if (movie == null)
            {
                throw new Exception($"La pelicula con ID: {id} no fue encontrada");
            }

            if (!string.IsNullOrWhiteSpace(model.Nombre)&& model.Nombre != "string")
            {
                movie.Nombre = model.Nombre;
            }
            if (!string.IsNullOrWhiteSpace(model.Descripcion)&& model.Descripcion != "string")
            {
                movie.Descripcion = model.Descripcion;
            }
            if(model.DuracionMinutos != null && model.DuracionMinutos > 0 )
            {
                movie.DuracionMinutos = (int)model.DuracionMinutos;
            }
            if (model.AñoLanzamiento != null && model.AñoLanzamiento > 0 )
            {
                movie.AñoLanzamiento = (int)model.AñoLanzamiento;
            }

            if (model.GeneroID.HasValue && model.GeneroID.Value > 0)
            {
                var genero = await _generoRepository.GetGenero(model.GeneroID.Value);
                if(genero == null)
                {
                    throw new Exception($"El género con ID {model.GeneroID} no existe");

                }
                movie.GeneroID = model.GeneroID.Value;
            }

            if (model.Imagen != null && model.Imagen.Length > 0)
            {
                var rutaCarpetaImg = Path.Combine("wwwroot", "img");
                if (!Directory.Exists(rutaCarpetaImg))
                {
                    Directory.CreateDirectory(rutaCarpetaImg);
                }
                var rutaimg = Path.Combine(rutaCarpetaImg, model.Imagen.FileName);
                using(var stream = new FileStream(rutaimg, FileMode.Create))
                {
                    await model.Imagen.CopyToAsync(stream);
                }
                movie.Imagen = "/img/" + model.Imagen.FileName;
            }

            await _peliculaRepository.UpdatePelicula(movie);
            return new ResponseDto
            {
                ID = movie.ID,
                Nombre = movie.Nombre,
                Descripcion = movie.Descripcion,
                Imagen = movie.Imagen,
                DuracionMinutos = movie.DuracionMinutos,
                AñoLanzamiento = movie.AñoLanzamiento,
                GeneroID = movie.GeneroID
            };
        }
    }
}
