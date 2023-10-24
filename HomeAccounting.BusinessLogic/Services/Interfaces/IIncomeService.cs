using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Services.Interfaces
{
    public interface IIncomeService
    {
        Task<List<IncomeDto>> GetIncomeAsync();
        Task<IncomeDto> GetIncomeDtoByIdAsync(int id);
        Task<IncomeDto>AddAsync(IncomeDto incomeDto);
        Task<IncomeDto>UpdateAsync(IncomeDto incomeDto);
        Task <IncomeDto>DeleteAsync(int id);
    }
}
