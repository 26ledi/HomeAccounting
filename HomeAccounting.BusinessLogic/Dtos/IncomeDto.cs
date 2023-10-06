using HomeAccounting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Dtos
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Member Person { get; set; }
        public int SourceIncomeId { get; set; }
        public SourceIncome SourceIncome { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
