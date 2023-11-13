using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Entities;
using HomeAccounting.Models.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Data
{
    public class DbContextHome :IdentityDbContext<IdentityUser>
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
            builder.SeedApplicationData();
        }
    }
}
