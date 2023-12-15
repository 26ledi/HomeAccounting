using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeAccounting.Models.Login
{
    public class LoginUser
    {
        [Required(ErrorMessage ="The email is required")]
        public string ?Email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string ?Password { get; set; }
    }
}
