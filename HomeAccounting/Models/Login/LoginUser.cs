using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeAccounting.Models.Login
{
    public class LoginUser
    {
        [Required(ErrorMessage ="The username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }
    }
}
