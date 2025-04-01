using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IMemberRepository
{
    
    Task<Member?> GetMemberByEmail(string email);
}