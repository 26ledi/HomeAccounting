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
    public class MemberRepository : IMemberRepository
    {
        private readonly DbContextHome _db;

        public MemberRepository(DbContextHome db) 
        {
            _db=db;
        }

        public async Task<Member?> GetMemberByNameAndSurname(string name, string surname)
        {
            return await _db.Members.FirstOrDefaultAsync(member => member.Name.Equals(name) && member.Surname.Equals(surname));
        }

        public async Task<Member>AddAsync(Member member)
        {
           _db.Members.Add(member);
           await _db.SaveChangesAsync();

           return member;
        }

        public async Task<Member>DeleteAsync(Member member)
        {
            _db.Members.Remove(member);
            await _db.SaveChangesAsync();

            return member;
        }

        public async Task<List<Member>>GetMemberAsync()
        {
            return await _db.Members.Include(m => m.family).Include(m => m.Incomes)
                .Include(m => m.Consumptions).AsNoTracking().ToListAsync();
        }
     
        public async Task<Member?>GetMemberByIdAsync(int id)
        {
            return await _db.Members.Include(m => m.Incomes).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Member>UpdateAsync(Member member)
        {
            _db.Members.Update(member);
            await _db.SaveChangesAsync();

            return member;
        }
    }
}
