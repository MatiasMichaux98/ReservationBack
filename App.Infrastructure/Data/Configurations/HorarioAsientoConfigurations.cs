using App.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Infrastructure.Data.Configurations
{
    public class HorarioAsientoConfigurations : IEntityTypeConfiguration<HorarioAsiento>
    {
        public void Configure(EntityTypeBuilder<HorarioAsiento> builder)
        {
            //relaciones 
            builder.HasOne(h => h.horario)
                   .WithMany(h => h.horarioAsientos)
                   .HasForeignKey(h => h.IdHorario)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.asiento)
                .WithMany(h => h.HorarioAsientos)
                .HasForeignKey(h => h.IdAsiento)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
