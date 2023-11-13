using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.Data.Entities;
using System.Collections.Generic;

namespace HomeAccounting.BusinessLogic.Services.Interfaces
{
    public interface IConsumptionService
    {
        Task<List<ConsumptionDto>> GetAsync();
        Task<ConsumptionDto> GetByIdAsync(int id);
        Task<ConsumptionDto> AddAsync(ConsumptionDto consumptionDto);
        Task<ConsumptionDto> UpdateAsync(ConsumptionDto consumptionDto);
        Task<ConsumptionDto> DeleteAsync(int id);
        Task<List<string>> GetFrequentConsumptionTypeByTimeAsync(DateTime startTime, DateTime endTime);
        Task<List<string>> GetFrequentConsumptionTypeByMonthAsync(int month, int year);
        Task<List<string>> GetFrequentConsumptionTypeByYearAsync(int year);
        Task<List<string>> GetMemberFrequentConsumptionByTimeAsync(DateTime startTime, DateTime endTime);
        Task<List<string>> GetMemberFrequentConsumptionByMonthAsync(int month ,int year);
        Task<List<string>> GetMemberFrequentConsumptionByYearAsync(int year);
        Task<List<(string Day, string Amount)>> GetDaysWithMaxConsumptionAsync();
        Task<List<(string Name, string Amount)>> GetMaxConsumptionNameByTime(DateTime startTime, DateTime endTime);
        Task<List<(string Name, string Amount)>> GetMaxConsumptionNameByMonth(int month,int year);
        Task<List<(string Name, string Amount)>> GetMaxConsumptionNameByYear(int year);
    }
}
