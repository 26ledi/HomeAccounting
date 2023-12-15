using Microsoft.AspNetCore.Identity;

namespace HomeAccounting.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
