using App.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class GeneroConfigurations : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            //relaciones 
            builder.HasMany(p => p.peliculas)
                   .WithOne(g => g.genero)
                   .HasForeignKey(p => p.GeneroID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
              new Genero { ID=1 , Nombre= "Accion" },
              new Genero { ID=2 , Nombre= "Aventura" },
              new Genero { ID=3 , Nombre= "Comedia" },
              new Genero { ID=4 , Nombre= "Drama" },
              new Genero { ID=5 , Nombre= "Terror" },
              new Genero { ID=6 , Nombre= "Romance" },
              new Genero { ID=7 , Nombre= "Fantasía" },
              new Genero { ID=8 , Nombre= "Musical" },
              new Genero { ID=9 , Nombre= "Suspenso " },
              new Genero { ID=10 , Nombre= "Ciencia Ficción" }

          );
        }
    }
}
