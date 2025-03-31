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

        public async Task<IList<Member>> GetAllAsync()
        {
            return await _dbContext.Members.ToListAsync();
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
    }
}