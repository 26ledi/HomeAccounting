using HomeAccounting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Interfaces
{
    public interface ISourceIncomeRepository
    {
        Task<List<SourceIncome>> GetAllSourceIncomeAsync();
        Task<SourceIncome?> GetSourceIncomeByIdAsync(int id);
        Task<SourceIncome> AddAsync(SourceIncome sourceIncome);
        Task<SourceIncome> UpdateAsync(SourceIncome sourceIncome);
        Task<SourceIncome> DeleteAsync(SourceIncome sourceIncome);
    }
}
