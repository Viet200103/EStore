using EStore.Business.DTOs;

namespace EStore.Business.Service.IService
{
    public interface IMemberService
    {
        Task<IList<MemberDTO>> GetMembersAsync();
        Task<MemberDTO> GetMemberByIdAsync(int id);
        Task<bool> UpdateMemberAsync(MemberDTO member);
        Task<bool> CreateMemberAsync(CreateMemberDTO member);
        Task<bool> DeleteMemberAsync(int id);
    }
}