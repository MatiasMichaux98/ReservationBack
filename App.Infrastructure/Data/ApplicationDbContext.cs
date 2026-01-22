using App.Domain.Entitie;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Infrastructure.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options
           ) : base(options) { }
        
        DbSet<Pelicula> peliculas  => Set<Pelicula>();
        DbSet<Asiento> asientos => Set<Asiento>();
        DbSet<Genero> generos => Set<Genero>();
        DbSet<Horario> horarios => Set<Horario>();
        DbSet<HorarioAsiento> horarioAsientos => Set<HorarioAsiento>();
        DbSet<Reservacion> reservaciones => Set<Reservacion>();
        DbSet<Sala> salas => Set<Sala>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
