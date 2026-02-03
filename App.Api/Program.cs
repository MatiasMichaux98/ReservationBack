using App.Application.Common.Interface;
using App.Application.Service;
using App.Infrastructure.Data;
using App.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Infrastructure.Middleware;
using App.Application.Common.Interface.HorarioInterface;
using App.Application.Common.Interface.SalaInterface;
using App.Application.Common.Interface.AsientoInterface;
using App.Application.Common.Interface.ReservacionInterface;
using App.Application.Common.Interface.HorarioAsientoInterface;
using App.Application.Common.Interface.GeneroInterface;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("GetConnection"),
    b => b.MigrationsAssembly("App.Infrastructure")));


builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();
builder.Services.AddScoped<IPerliculaService, PeliculaService>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IHorarioRepository, HorarioRepository>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<ISalaRepository, SalaRepository>();
builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();
builder.Services.AddScoped<IHorarioAsientoRepository, HorarioAsientoRepository>();
builder.Services.AddScoped<IReservationRepository, ReservacionRepository>();
builder.Services.AddScoped<IReservacionService, ReservacionService>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IAsientoService, AsientoService>();
builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
