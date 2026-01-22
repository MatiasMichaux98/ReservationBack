using App.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class ReservacionConfigurations : IEntityTypeConfiguration<Reservacion>
    {
        public void Configure(EntityTypeBuilder<Reservacion> builder)
        {
            //relaciones
            builder.HasOne(h => h.horario)
                  .WithMany(h => h.reservaciones)
                  .HasForeignKey(h => h.IdHorario)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.asiento)
                .WithMany(h => h.reservaciones)
                .HasForeignKey(h => h.IdHorario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
