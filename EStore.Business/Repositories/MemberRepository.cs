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

        public async Task<bool> CreateMember(Member member)
        {
            
            string normalizedEmail = member.Email.Trim().ToLower();
            bool isExisted = await _dbContext.Members.AnyAsync(x => x.Email == normalizedEmail);
            if (isExisted)
            {
                throw new Exception($"Email {member.Email} already exists");
            }
            
            _dbContext.Add(member);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteMember(int id)
        {
            _dbContext.Remove(new Member() { MemberId = id });
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Member?> GetMemberById(int id)
        {
            return await _dbContext.Members.FirstOrDefaultAsync(m => m.MemberId == id);
        }

        public async Task<bool> UpdateMember(Member member)
        {
            var memberToUpdate = await _dbContext.Members.FirstOrDefaultAsync(x => x.MemberId == member.MemberId);
            if (memberToUpdate == null)
            {
                throw new Exception($"Member does not exist");
            }

            memberToUpdate.Email = member.Email;
            memberToUpdate.CompanyName = member.CompanyName ?? memberToUpdate.CompanyName;
            memberToUpdate.City = member.City ?? memberToUpdate.City;
            memberToUpdate.Country = member.Country ?? memberToUpdate.Country;
            
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
        
        public async Task<Member?> GetMemberByEmail(string email)
        {
            return await _dbContext.Members
                .Select(m => new Member
                {
                    MemberId = m.MemberId,
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
                .OrderByDescending(member => member.MemberId)
                .Skip((pageNumber - 1)  * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            return (members, totalPage);
        }

        public async Task<List<Member>> GetAllAsync()
        {
            return await _dbContext.Members.ToListAsync();
        }
    }
}