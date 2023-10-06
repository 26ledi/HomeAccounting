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
        Task<List<FamilyDto>> GetAllFamilyAsync();
        Task<FamilyDto> AddAsync(Family family);
        Task<FamilyDto> UpdateAsync(int id);
        Task<FamilyDto> DeleteAsync(int id);
    }
}
