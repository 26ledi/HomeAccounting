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

        async Task<Family> IFamilyRepository.AddAsync(Family family)
        {
            _db.Families.Add(family);
            await _db.SaveChangesAsync();
            return family;
        }

        async Task<Family> IFamilyRepository.DeleteAsync(Family family)
        {
            _db.Families.Remove(family);
            await _db.SaveChangesAsync();
            return family;
        }

        async Task<List<Family>> IFamilyRepository.GetAllFamilyAsync()
        {
            return await _db.Families.AsNoTracking().ToListAsync();
        }

        async Task<Family?> IFamilyRepository.GetFamilyByIdAsync(int id)
        {
            return await _db.Families.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        async Task<Family> IFamilyRepository.UpdateAsync(Family family)
        {
            _db.Families.Update(family);
            await _db.SaveChangesAsync();
            return family;
        }
    }
}
