using HomeAccounting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        Task<List<Income>>GetAllIncomeAsync();
        Task<Income>GetIncomeByIdAsync(int id);
        Task<Income>AddAsync(Income income);
        Task<Income>UpdateAsync(Income income);
        Task<Income>DeleteAsync(Income income);
    }
}
