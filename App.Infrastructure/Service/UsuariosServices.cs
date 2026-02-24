using App.Application.Common.Interface.UsuarioInterface;
using App.Infrastructure.Data;
using App.Infrastructure.Entitie;
using App.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;


using App.Infrastructure.Exceptions;

namespace App.Infrastructure.Service
{
    public class UsuariosServices 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly ApplicationDbContext _context;
        public UsuariosServices(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _context = context;
        }

       
    }
}
