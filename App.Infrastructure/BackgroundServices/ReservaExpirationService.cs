using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace App.Infrastructure.BackgroundServices
{
    public class ReservaExpirationService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public ReservaExpirationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var ahora = DateTime.Now;
                var reservasExpiradas = await context.Reservaciones
                    .Where(r => r.estadoReserva == Domain.Enums.EstadoReserva.Pendiente &&
                           r.ExpiraEn < ahora)
                    .ToListAsync(stoppingToken);

                foreach(var r in reservasExpiradas)
                {
                    r.estadoReserva = Domain.Enums.EstadoReserva.Cancelada;
                }
                await context.SaveChangesAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
