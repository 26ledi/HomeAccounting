using HomeAccounting.Data.Entities;

namespace HomeAccounting.BusinessLogic.Dtos
{
    public class ConsumptionDto
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int ConsumptionTypeId { get; set; }
        public ConsumptionType ?ConsumptionType { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public DateTime ?StartDate { get; set; }
        public DateTime ?EndDate { get; set; }
        public List<string> ?List { get; set; }
        public List<string>? FrequentByMonthList { get; set; }
        public List<string>? FrequentByYearList { get; set; }
        public List<string>? FrequentMembersByTime { get; set; }
        public List<string>? FrequentMembersByMonth { get; set; }
        public List<string>? FrequentMembersByYear { get; set; }
        public List<(string Day,string Amount)>? MaxDayofWeeks { get; set; }
        public List<(string Name,string Amount)>? MaxConsumptionByTime { get; set; }
        public List<(string Name, string Amount)>? MaxConsumptionByMonth { get; set; }
        public List<(string Name, string Amount)>? MaxConsumptionByYear { get; set; }
    }
}
