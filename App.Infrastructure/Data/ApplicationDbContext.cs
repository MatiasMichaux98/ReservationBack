using App.Domain.Entitie;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options) { }

        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Asiento> Asientos => Set<Asiento>();
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Horario> Horarios => Set<Horario>();
        public DbSet<HorarioAsiento> HorarioAsientos => Set<HorarioAsiento>();
        public DbSet<Reservacion> Reservaciones => Set<Reservacion>();
        public DbSet<Sala> Salas => Set<Sala>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
