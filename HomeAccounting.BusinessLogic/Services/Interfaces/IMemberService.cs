using HomeAccounting.Data.Entities;
using HomeAccounting.BusinessLogic.Dtos;

namespace HomeAccounting.BusinessLogic.Services.Interfaces
{
    public interface IMemberService
    {
        
        Task<double> CalculateIncomeMemberForGivenMonthAsync(int id, int year, int month);
        Task<double> CalculateIncomeMemberForGivenYearAsync(int id , int year);
        Task<double> GetHighestIncomeYearAsync(int id, int year);
        Task<double> GetHighestIncomeMonthAsync(int id, int year, int month);
        Task<MemberDto> GetMemberByIdAsync(int id);
        Task<List<MemberDto>> GetMemberDtoAsync();
        Task<MemberDto> AddAsync(MemberDto member);
        Task<MemberDto> UpdateAsync(MemberDto member);
        Task<MemberDto> DeleteAsync(MemberDto member);
    }
}
