using HomeAccounting.Data;
using HomeAccounting.DataAccess.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.DataAccess.Repositories.Implementations
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly DbContextHome _db;

        public FamilyRepository(DbContextHome db)
        {
            _db = db;
        }

       public async Task<Family>AddAsync(Family family)
        {
            _db.Families.Add(family);
            await _db.SaveChangesAsync();
            return family;
        }

        public async Task<Family>DeleteAsync(Family family)
        {
            _db.Families.Remove(family);
            await _db.SaveChangesAsync();
            return family;
        }

        public async Task<List<Family>> GetAllFamilyAsync()
        {
            return await _db.Families
                .Include(f => f.FamilyMember)
                    .ThenInclude(fm => fm.Incomes)
                .Include(f => f.FamilyMember)
                    .ThenInclude(fm => fm.Consumptions)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Family?>GetFamilyByNameAsync(string name)
        {
            return await _db.Families.AsNoTracking().FirstOrDefaultAsync(x => x.FamilyName == name);
        }

       public async Task<Family?>GetFamilyByIdAsync(int id)
        {
            return await _db.Families.Include(f => f.FamilyMember).ThenInclude(f => f.Incomes).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Family>UpdateAsync(Family family)
        {
            _db.Families.Update(family);
            await _db.SaveChangesAsync();

            return family;
        }
    }
}
