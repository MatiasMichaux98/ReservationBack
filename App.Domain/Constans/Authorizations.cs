
namespace App.Domain.Constans
{
    public class Authorizations
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }

        public const Roles default_role = Roles.User;
    }
}
