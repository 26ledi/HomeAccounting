using System.ComponentModel.DataAnnotations;

namespace HomeAccounting.Data.Entities
{
    public class SourceIncome
    {
        public int Id { get; set; }
        public string ?Name {  get; set; }
        public string ?Description {  get; set; }
        public List<Income> Incomes { get; set; }

    }
}
