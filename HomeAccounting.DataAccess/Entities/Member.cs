using HomeAccounting.DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeAccounting.Data.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int FamilyId { get; set; }
        public Family family { get; set; }
        public List<Consumption> Consumptions { get; set; }
        public List<Income> Incomes { get; set; }
    }
    
}
