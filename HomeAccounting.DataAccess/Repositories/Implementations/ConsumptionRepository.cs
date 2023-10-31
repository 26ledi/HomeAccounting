using HomeAccounting.Data;
using HomeAccounting.Data.Entities;
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

    public async Task<Consumption>AddAsync(Consumption consumption)
    {
        _db.Consumptions.Add(consumption);
        await _db.SaveChangesAsync();

        return consumption;
    }

    public async Task<Consumption>DeleteAsync(Consumption consumption)
    {
        _db.Consumptions.Remove(consumption);
        await _db.SaveChangesAsync();

        return consumption;
    }

    public async Task<List<Consumption>>GetAllConsumptionAsync()
    {
        return await _db.Consumptions.Include(c => c.Member).ThenInclude(c => c.family).Include(c => c.ConsumptionType).AsNoTracking().ToListAsync();
    }

    public async Task<Consumption?>GetConsumptionByIdAsync(int id)
    {
        return await _db.Consumptions.Include(c => c.Member).ThenInclude(c => c.family).Include(c => c.ConsumptionType).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

    }

    public async Task<Consumption>UpdateAsync(Consumption consumption)
    {
        _db.Consumptions.Update(consumption);
        await _db.SaveChangesAsync();

        return consumption;
    }
}
