using HomeAccounting.DataAccess.Entities;

namespace HomeAccounting.DataAccess.Repositories.Interfaces
{
    public interface IFamilyRepository
    {
        Task<List<Family>> GetAllFamilyAsync();
        Task<Family?> GetFamilyByNameAsync(string name);
        Task<Family?> GetFamilyByIdAsync(int id);
        Task<Family> AddAsync(Family family);
        Task<Family> UpdateAsync(Family family);
        Task<Family> DeleteAsync(Family family);
    }
}
