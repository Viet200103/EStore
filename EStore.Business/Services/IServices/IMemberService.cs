using EStore.Business.DTOs;

namespace EStore.Business.Services.IServices
{
    public interface IMemberService
    {
        Task<(IEnumerable<MemberDTO> membersDTO, int totalPage)> GetMembers(int pageNumber, int pageSize);
        Task<List<MemberDTO>> GetAllMembersAsync();
        Task<MemberDTO?> GetMemberById(int id);
        Task<bool> UpdateMember(MemberDTO member);
        Task<bool> CreateMemberAsync(CreateMemberDTO member);
        Task<bool> DeleteMember(int id);
    }
}