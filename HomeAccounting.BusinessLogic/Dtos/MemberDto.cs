using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Dtos
{
    public class MemberDto
    {
        public int? Id { get; set; }
        [Required]
        [MinLength(3)]
        public string ?Name { get; set; }

        public string ?Surname { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Birthday { get; set; }
        public int MemberId { get; set; }
        public Member ? member { get; set; }
        public double ?Balance {  get; set; }
        public double? BalanceIncomeMonth { get; set; }
        public double? BalanceIncomeYear { get; set; }
        public double? HighestIncomeTime { get; set; }
        public double? HighestIncomeMonth { get; set; }
        public double? HighestIncomeYear { get; set; }
        public int FamilyId { get; set; }
        public Family? family { get; set; }
       
    }
}
