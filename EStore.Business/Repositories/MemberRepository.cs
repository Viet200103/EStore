using EStore.Data.Database;
using EStore.Data.Models;
using EStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EStore.Business.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly EStoreDbContext _dbContext;

        public MemberRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateMemberAsync(Member member)
        {
            try
            {
                _dbContext.Add(member);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public async Task<bool> DeleteMemberAsync(int id)
        {
            try
            {
                _dbContext.Remove(await GetByIdAsync(id));
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public Task<Member> GetByIdAsync(int id)
        {
            return _dbContext.Members.FirstOrDefaultAsync(m => m.MemberId == id);
        }

        public async Task<bool> UpdateMemberAsync(Member member)
        {
            try
            {
                _dbContext.Members.Update(member);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        
        public async Task<Member?> GetMemberByEmail(string email)
        {
            return await _dbContext.Members
                .Select(m => new Member
                {
                    Email = m.Email,
                    Password = m.Password,
                })
                .SingleOrDefaultAsync(m => m.Email == email);
        }

        public async Task<(IEnumerable<Member> members, int totalPage)> GetMembers(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            
            IQueryable<Member> query = _dbContext.Members
                .TagWith("GetMembers")
                .AsNoTracking();
            
            int count = await query.CountAsync();
            var totalPage = count == 0 ? 1 : (int) Math.Ceiling((double) count / pageSize);
            
            IEnumerable<Member> members = await query
                .Skip((pageNumber - 1)  * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            return (members, totalPage);
        }
    }
}