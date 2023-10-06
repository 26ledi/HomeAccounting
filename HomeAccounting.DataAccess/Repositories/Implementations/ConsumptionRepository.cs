using HomeAccounting.Data;
using HomeAccounting.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.DataAccess.Repositories.Implementations;

public class ConsumptionRepository : IConsumptionRepository
{
    private readonly DbContextHome _db;

    public ConsumptionRepository(DbContextHome db)
    {
        _db = db;
    }

    async Task<Data.Entities.Consumption> IConsumptionRepository.AddAsync(Data.Entities.Consumption consumption)
    {
        _db.Consumptions.Add(consumption);
        await _db.SaveChangesAsync();

        return consumption;
    }

    async Task<Data.Entities.Consumption> IConsumptionRepository.DeleteAsync(Data.Entities.Consumption consumption)
    {
        _db.Consumptions.Remove(consumption);
        await _db.SaveChangesAsync();

        return consumption;
    }

    async Task<List<Data.Entities.Consumption>> IConsumptionRepository.GetAllConsumptionAsync()
    {
        return await _db.Consumptions.AsNoTracking().ToListAsync();
    }

    async Task<Data.Entities.Consumption?> IConsumptionRepository.GetConsumptionByIdAsync(int id)
    {
        return await _db.Consumptions.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

    }

    async Task<Data.Entities.Consumption> IConsumptionRepository.UpdateAsync(Data.Entities.Consumption consumption)
    {
        _db.Consumptions.Update(consumption);
        await _db.SaveChangesAsync();

        return consumption;
    }
}
