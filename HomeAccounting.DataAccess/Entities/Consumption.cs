using System.ComponentModel.DataAnnotations;

namespace HomeAccounting.Data.Entities
{
    public class Consumption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int ConsumptionTypeId { get; set; }
        public ConsumptionType ConsumptionType { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public double Amount { get; set; }

    }
}
