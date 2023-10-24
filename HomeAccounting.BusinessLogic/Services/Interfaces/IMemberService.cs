using HomeAccounting.Data.Entities;
using HomeAccounting.BusinessLogic.Dtos;

namespace HomeAccounting.BusinessLogic.Services.Interfaces
{
    public interface IMemberService
    {

        Task<double> CalculateIncomeGivingTimeAsync(int id, DateTime startTime, DateTime endTime);
        Task<double> CalculateIncomeForMonthAsync(int id, int year, int month);
        Task<double> CalculateIncomeMemberForYearAsync(int id, int year);
        Task<double> GetHighestIncomeGivingTimeAsync(int id, DateTime startime, DateTime endtime);
        Task<double> GetHighestIncomeMonthAsync(int id, int year, int month);
        Task<double> GetHighestIncomeYearAsync(int id, int year);
        Task<MemberDto> GetMemberByIdAsync(int id);
        Task<List<MemberDto>> GetMemberDtoAsync();
        Task<MemberDto> AddAsync(MemberDto member);
        Task<MemberDto> UpdateAsync(MemberDto member);
        Task<MemberDto> DeleteAsync(MemberDto member);
    }
}
