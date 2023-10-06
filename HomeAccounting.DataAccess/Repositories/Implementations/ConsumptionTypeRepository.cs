using HomeAccounting.Data;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Implementations
{
    public class ConsumptionTypeRepository:IConsumptionTypeRepository
    {
        private readonly DbContextHome _db;
        public ConsumptionTypeRepository(DbContextHome db)
        {
            _db = db;
        }

        async Task<ConsumptionType> IConsumptionTypeRepository.AddAsync(ConsumptionType consumptionType)
        {
            _db.ConsumptionTypes.Add(consumptionType);
            await _db.SaveChangesAsync();
            return consumptionType;
        }

        async Task<ConsumptionType> IConsumptionTypeRepository.DeleteAsync(ConsumptionType consumptionType)
        {
            _db.ConsumptionTypes.Remove(consumptionType);
            await _db.SaveChangesAsync();
            return consumptionType;
        }

        async Task<List<ConsumptionType>> IConsumptionTypeRepository.GetAllConsumptionTypesAsync()
        {
            return await _db.ConsumptionTypes.AsNoTracking().ToListAsync();
        }

        async Task<ConsumptionType> IConsumptionTypeRepository.GetConsumptionTypeByIdAsync(int id)
        {
            return await _db.ConsumptionTypes.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        async Task<ConsumptionType> IConsumptionTypeRepository.UpdateAsync(ConsumptionType consumptionType)
        {
            _db.ConsumptionTypes.Update(consumptionType);
            await _db.SaveChangesAsync();
            return consumptionType;
        }
    }
}
