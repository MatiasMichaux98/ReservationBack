using App.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class AsientoConfigurations : IEntityTypeConfiguration<Asiento>
    {
        public void Configure(EntityTypeBuilder<Asiento> builder)
        {
            builder.HasKey(a => a.ID);

            //relaciones 
            builder.HasMany(a => a.HorarioAsientos)
                .WithOne(ha => ha.asiento)
                .HasForeignKey(ha => ha.IdAsiento)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.sala)
              .WithMany(h => h.asientos)
              .HasForeignKey(h => h.IdSala)
              .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(

                new Asiento { ID = 1, NumeroAsiento = "A1", IdSala = 1 },
                new Asiento { ID = 2, NumeroAsiento = "A2", IdSala = 1 },
                new Asiento { ID = 3, NumeroAsiento = "A3", IdSala = 1 },
                new Asiento { ID = 4, NumeroAsiento = "A4", IdSala = 1 },
                new Asiento { ID = 5, NumeroAsiento = "A5", IdSala = 1 },

                new Asiento { ID = 6, NumeroAsiento = "B6", IdSala = 2 },
                new Asiento { ID = 7, NumeroAsiento = "B7", IdSala = 2 },
                new Asiento { ID = 8, NumeroAsiento = "B8", IdSala = 2 },
                new Asiento { ID = 9, NumeroAsiento = "B9", IdSala = 2 },
                new Asiento { ID = 10, NumeroAsiento = "B10", IdSala = 2 }


            );


        }
    }
}
