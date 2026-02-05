using App.Domain.Entitie;
using App.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class ReservacionConfigurations : IEntityTypeConfiguration<Reservacion>
    {
        public void Configure(EntityTypeBuilder<Reservacion> builder)
        {
            builder.HasQueryFilter(a => a.estadoReserva != EstadoReserva.Cancelada);

            //relaciones
            builder.HasOne(h => h.horario)
                  .WithMany(h => h.reservaciones)
                  .HasForeignKey(h => h.IdHorario)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.asiento)
                .WithMany(h => h.reservaciones)
                .HasForeignKey(h => h.IdAsiento)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
