using EStore.Data.Database;
using EStore.Data.Models;
using EStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EStore.Business.Repositories
{
    public class MemberRepository(EStoreDbContext dbContext): IMemberRepository
    {
        public async Task<Member?> GetMemberByEmail(string email)
        {
            return await dbContext.Members
                .Select(m => new Member
                {
                    Email = m.Email,
                    Password = m.Password,
                })
                .SingleOrDefaultAsync(m => m.Email == email);
        }
    }
}