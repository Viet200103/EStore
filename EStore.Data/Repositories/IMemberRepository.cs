using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IMemberRepository
{
    Task<bool> CreateMemberAsync(Member member);
    Task<bool> DeleteMemberAsync(int id);
    Task<IList<Member>> GetAllAsync();
    Task<Member> GetByIdAsync(int id);
    Task<bool> UpdateMemberAsync(Member member);
    Task<Member?> GetMemberByEmail(string email);
}