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
using App.Infrastructure.Entitie;
using Microsoft.AspNetCore.Identity;
using App.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using App.Application.Common.Interface.AuthInterface;
using App.Infrastructure.Service;
var builder = WebApplication.CreateBuilder(args);

// Configuracion JWT
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

// Add configuracion identity 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("GetConnection"),
    b => b.MigrationsAssembly("App.Infrastructure")));

//agregar Athentication - JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});


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
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await ApplicationDbContextSeed.SeedEssentialAsync(userManager, roleManager);

    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrio un error al inicializar db ");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
