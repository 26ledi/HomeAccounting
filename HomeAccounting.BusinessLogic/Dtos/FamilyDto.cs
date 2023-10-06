using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Dtos
{
    public class FamilyDto
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public List<Data.Entities.Member> FamilyMember { get; set; }
    }
}
