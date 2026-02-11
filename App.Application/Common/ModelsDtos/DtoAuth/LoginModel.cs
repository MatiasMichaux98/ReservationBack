using System.ComponentModel.DataAnnotations;


namespace App.Application.Common.ModelsDtos.DtoAuth
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
