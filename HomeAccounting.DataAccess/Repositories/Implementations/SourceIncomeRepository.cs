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
    public class SourceIncomeRepository : ISourceIncomeRepository
    {
        private readonly DbContextHome _db;
        public SourceIncomeRepository(DbContextHome  db) 
        {
            _db = db;
        }
        public async Task<SourceIncome>AddAsync(SourceIncome sourceIncome)
        {
            _db.SourceIncomes.Add(sourceIncome);
            await _db.SaveChangesAsync();
            return sourceIncome;
        }

        public async Task<SourceIncome>DeleteAsync(SourceIncome sourceIncome)
        {
            _db.SourceIncomes.Remove(sourceIncome);
            await _db.SaveChangesAsync();
            return sourceIncome;
        }

       public async Task<List<SourceIncome>>GetAllSourceIncomeAsync()
        {
            return await _db.SourceIncomes.AsNoTracking().ToListAsync();
        }

        public async Task<SourceIncome?>GetSourceIncomeByIdAsync(int id)
        {
            return await _db.SourceIncomes.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<SourceIncome>UpdateAsync(SourceIncome sourceIncome)
        {
            _db.SourceIncomes.Update(sourceIncome);
            await _db.SaveChangesAsync();
            return sourceIncome;
        }
    }
}
