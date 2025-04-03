using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IMemberRepository
{
    Task<bool> CreateMemberAsync(Member member);
    Task<bool> DeleteMemberAsync(int id);
    Task<Member> GetByIdAsync(int id);
    Task<Member?> GetByEmailAsync(string email);
    Task<bool> UpdateMemberAsync(Member member);
    Task<Member?> GetMemberByEmail(string email);
    Task<(IEnumerable<Member> members, int totalPage)> GetMembers(int pageNumber, int pageSize);
}