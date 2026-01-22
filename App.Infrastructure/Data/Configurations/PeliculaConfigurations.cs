using App.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Data.Configurations
{
    public class PeliculaConfigurations : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            //relaciones
            builder.HasOne(h => h.genero)
                   .WithMany(h => h.peliculas)
                   .HasForeignKey(h => h.GeneroID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.horarios)
                   .WithOne(p => p.pelicula)
                   .HasForeignKey(p => p.IdPelicula)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
