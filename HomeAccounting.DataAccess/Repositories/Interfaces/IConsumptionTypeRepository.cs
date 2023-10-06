using HomeAccounting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Interfaces
{
    public interface IConsumptionTypeRepository
    {
        Task<List<ConsumptionType>> GetAllConsumptionTypesAsync();
        Task<ConsumptionType> GetConsumptionTypeByIdAsync(int id);
        Task<ConsumptionType> AddAsync(ConsumptionType consumptionType);
        Task<ConsumptionType> UpdateAsync(ConsumptionType consumptionType);
        Task<ConsumptionType> DeleteAsync(ConsumptionType consumptionType);
    }
}
