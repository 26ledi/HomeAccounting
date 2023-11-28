using HomeAccounting.Data.Entities;

namespace HomeAccounting.BusinessLogic.Dtos
{
    public class FamilyDto
    {
        public int? Id { get; set; }
        public string? FamilyName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double? BalanceTime { get; set; }
        public double? BalanceIncomeMonth { get; set; }
        public double? BalanceIncomeYear { get; set; }
        public double? HighestIncomeTime { get; set; }
        public double? HighestIncomeMonth { get; set; }
        public double? HighestIncomeYear { get; set; }
        public List<MemberDto>? FamilyMember { get; set; }
        public int? MemberId { get; set; }
        public Member? member { get; set; }
    }
}
