using App.Application.Common.ModelsDtos.DtoAuth;
using App.Domain.Entitie;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Entitie
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<RefreshTokenModel> refreshTokens { get; set; }
    }
}
