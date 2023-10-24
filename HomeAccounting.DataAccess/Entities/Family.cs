using HomeAccounting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Entities
{
    public class Family
    {
        public int Id { get; set; }
        public string ?FamilyName {  get; set; }
        public List<Member>?FamilyMember {  get; set; }
    }
}
