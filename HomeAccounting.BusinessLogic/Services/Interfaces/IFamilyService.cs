using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinessLogic.Services.Interfaces
{
    public interface IFamilyService
    {
        Task<double> CalculateIncomeGivingTimeAsync(int id, DateTime startTime, DateTime endTime);
        Task<double> CalculateIncomeForMonthAsync(int memberId, int year, int month);
        Task<double> CalculateIncomeForYearAsync(int id, int year);
        Task<double>GetHighestIncomeGivingTimeAsync(int id, DateTime startime, DateTime endtime);
        Task<double> GetHighestIncomeMonthAsync(int id, int year, int month);
        Task<double> GetHighestIncomeYearAsync(int id, int year);
        Task<List<FamilyDto>> GetAllFamilyAsync();
        Task<FamilyDto> GetAllFamilyByIdAsync(int id);
        Task<FamilyDto> AddAsync(FamilyDto familyDto);
        Task<FamilyDto> UpdateAsync(FamilyDto familyDto);
        Task<FamilyDto> DeleteAsync(int id);
    }
}
