using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Interfaces
{
    public interface IFamilyRepository
    {
        Task<List<Family>> GetAllFamilyAsync();
        Task<Family?> GetFamilyByIdAsync(int id);
        Task<Family> AddAsync(Family family);
        Task<Family> UpdateAsync(Family family);
        Task<Family> DeleteAsync(Family family);
    }
}
