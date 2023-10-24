using HomeAccounting.Data;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Implementations
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly DbContextHome _db;
        public IncomeRepository(DbContextHome db)
        {
            _db = db;
        }
        public async Task<Income>AddAsync(Income income)
        {
            _db.Incomes.Add(income);
           await _db.SaveChangesAsync();

            return income;
        }
        public async Task<Income>DeleteAsync(Income income)
        {
            _db.Incomes.Remove(income);
            await _db.SaveChangesAsync();

            return income;  
        }

        public async Task<List<Income>>GetAllIncomeAsync()
        {
            return await _db.Incomes.AsNoTracking().Include(i => i.Member).ThenInclude(i => i.family).Include(i =>i.SourceIncome).ToListAsync();
        }

        public async Task<Income?>GetIncomeByIdAsync(int id)
        {
            return await _db.Incomes.AsNoTracking().Include(i => i.Member).ThenInclude(i => i.family).Include(i => i.SourceIncome).FirstOrDefaultAsync(i=>i.Id==id);

        }
        public async Task<Income>UpdateAsync(Income income)
        {
            _db.Incomes.Update(income);
            await _db.SaveChangesAsync();
            return income;
        }
    }
}
