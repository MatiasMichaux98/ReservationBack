

using App.Application.Common.ModelsDtos.DtoAuth;

namespace App.Application.Common.Interface.AuthInterface
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthenticateModel> LoginAsync(LoginModel model);
        Task<AuthenticateModel> RefreshTokenAsync(string token);
        bool revokeToken(string token);
    }
}
