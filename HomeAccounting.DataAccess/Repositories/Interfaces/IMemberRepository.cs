using HomeAccounting.Data.Entities;

namespace HomeAccounting.DataAccess.Repositories.Interfaces;

public interface IMemberRepository
{
    Task<List<Member>> GetMemberAsync();
    Task<Member?> GetMemberByIdAsync(int id);
    Task<Member>AddAsync(Member member);
    Task<Member> UpdateAsync(Member member);
    Task<Member> DeleteAsync(Member member);
    Task<Member?> GetMemberByNameAndSurname(string name, string surname);
   
}
