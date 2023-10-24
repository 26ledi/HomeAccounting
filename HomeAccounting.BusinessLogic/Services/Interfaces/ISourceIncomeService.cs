using HomeAccounting.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Services.Interfaces
{
    public interface ISourceIncomeService
    {
        Task<List<SourceIncomeDto>> GetSourceIncomeAsync();
        Task<SourceIncomeDto> GetSourceIncomeDtoByIdAsync(int id);
        Task<SourceIncomeDto> AddAsync(SourceIncomeDto sourceIncomeDto);
        Task<SourceIncomeDto> UpdateAsync(SourceIncomeDto sourceIncomeDto);
        Task<SourceIncomeDto> DeleteAsync(int id);
    }
}
