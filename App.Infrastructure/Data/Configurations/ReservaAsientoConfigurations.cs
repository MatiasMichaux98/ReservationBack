using App.Domain.Entities;
using App.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class ReservaAsientoConfigurations : IEntityTypeConfiguration<ReservaAsiento>
    {
        public void Configure(EntityTypeBuilder<ReservaAsiento> builder)
        {
            builder.HasQueryFilter(a => a.reservacion.estadoReserva != EstadoReserva.Cancelada);

            //relaciones 
            builder.HasOne(h => h.reservacion)
                   .WithMany(h => h.ReservaAsientos)
                   .HasForeignKey(h => h.reservacionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.asiento)
                .WithMany(h => h.ReservaAsientos)
                .HasForeignKey(h => h.asientoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
