using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Data
{
    public class DbContextHome : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<SourceIncome> SourceIncomes { get; set; }
        public DbSet<ConsumptionType> ConsumptionTypes { get; set; }

        public DbContextHome(DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Member>().HasIndex(member => new { member.Surname, member.Name }).IsUnique();
        }
       
    }
}
