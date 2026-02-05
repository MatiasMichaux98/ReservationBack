using App.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class HorarioConfigurations : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {

            builder.HasQueryFilter(a => !a.isDeleted);

            //relaciones
            builder.HasOne(h => h.pelicula)
                .WithMany(h => h.horarios)
                .HasForeignKey(h => h.IdPelicula)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.sala)
                .WithMany(h => h.horarios)
                .HasForeignKey(h => h.IdSala)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.horarioAsientos)
                   .WithOne(h => h.horario)
                   .HasForeignKey(h => h.IdHorario)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.reservaciones)
                .WithOne(h => h.horario)
                .HasForeignKey(h => h.IdHorario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
