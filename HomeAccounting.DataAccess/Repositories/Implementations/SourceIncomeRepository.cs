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
        async Task<SourceIncome> ISourceIncomeRepository.AddAsync(SourceIncome sourceIncome)
        {
            _db.SourceIncomes.Add(sourceIncome);
            await _db.SaveChangesAsync();
            return sourceIncome;
        }

        async Task<SourceIncome> ISourceIncomeRepository.DeleteAsync(SourceIncome sourceIncome)
        {
            _db.SourceIncomes.Remove(sourceIncome);
            await _db.SaveChangesAsync();
            return sourceIncome;
        }

        async Task<List<SourceIncome>> ISourceIncomeRepository.GetAllSourceIncomeAsync()
        {
            return await _db.SourceIncomes.AsNoTracking().ToListAsync();
        }

        async Task<SourceIncome?> ISourceIncomeRepository.GetConsumptionTypeByIdAsync(int id)
        {
            return await _db.SourceIncomes.FirstOrDefaultAsync(i => i.Id == id);
        }

        async Task<SourceIncome> ISourceIncomeRepository.UpdateAsync(SourceIncome sourceIncome)
        {
            _db.SourceIncomes.Update(sourceIncome);
            await _db.SaveChangesAsync();
            return sourceIncome;
        }
    }
}
