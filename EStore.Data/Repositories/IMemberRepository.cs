using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IMemberRepository
{
    Task<bool> CreateMember(Member member);
    Task<bool> DeleteMember(int id);
    Task<Member?> GetMemberById(int id);
    Task<bool> UpdateMember(Member member);
    Task<Member?> GetMemberByEmail(string email);
    Task<(IEnumerable<Member> members, int totalPage)> GetMembers(int pageNumber, int pageSize);
}