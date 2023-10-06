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
        async Task<Income> IIncomeRepository.AddIAsync(Income income)
        {
            _db.Incomes.Add(income);
           await _db.SaveChangesAsync();
            return income;

        }

        async Task<Income> IIncomeRepository.DeleteAsync(Income income)
        {
            _db.Incomes.Remove(income);
            await _db.SaveChangesAsync();
            return income;
            
        }

        async Task<List<Income>>IIncomeRepository.GetAllIncomeAsync()
        {
            return await _db.Incomes.AsNoTracking().ToListAsync();
        }

        async Task<Income?> IIncomeRepository.GetIncomeByIdAsync(int id)
        {
            return await _db.Incomes.FirstOrDefaultAsync(i=>i.Id==id);

        }

        async Task<Income> IIncomeRepository.UpdateAsync(Income income)
        {
            _db.Incomes.Update(income);
            await _db.SaveChangesAsync();
            return income;
        }
    }
}
