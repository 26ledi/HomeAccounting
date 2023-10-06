using HomeAccounting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Interfaces
{
    public interface IConsumptionRepository
    {
        Task<List<Consumption>>GetAllConsumptionAsync();
        Task<Consumption?>GetConsumptionByIdAsync(int id);
        Task<Consumption>AddAsync(Consumption consumption);
        Task<Consumption>UpdateAsync(Consumption consumption);
        Task<Consumption>DeleteAsync(Consumption consumption);
    }
}
