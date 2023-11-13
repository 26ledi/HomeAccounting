using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Entities
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email {  get; set; }
    }
}
