using App.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class SalaConfigurations : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            //relaciones
            builder.HasMany(h => h.horarios)
                .WithOne(h => h.sala)
                .HasForeignKey(h => h.IdSala)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.asientos)
               .WithOne(h => h.sala)
               .HasForeignKey(h => h.IdSala)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(

                new Sala { ID = 1, Nombre = "Sala 1" },
                new Sala { ID = 2, Nombre = "Sala 2" }

            );
        }
    }
}
