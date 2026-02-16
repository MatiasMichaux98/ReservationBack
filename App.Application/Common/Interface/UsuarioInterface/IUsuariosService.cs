using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interface.UsuarioInterface
{
    public interface IUsuariosService
    {
        Task<string> GetUsers();
        Task<string?> GetUsersId(string Id);
    }
}
