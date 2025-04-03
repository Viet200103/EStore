using EStore.Business.DTOs;

namespace EStore.Business.Services.IServices
{
    public interface IMemberService
    {
        Task<(IEnumerable<MemberDTO> membersDTO, int totalPage)> GetMembers(int pageNumber, int pageSize);
        Task<MemberDTO> GetMemberByIdAsync(int id);
        Task<bool> UpdateMemberAsync(MemberDTO member);
        Task<bool> CreateMemberAsync(CreateMemberDTO member);
        Task<bool> DeleteMemberAsync(int id);
    }
}