using AutoMapper;
using EStore.Business.DTOs;
using EStore.Business.Services.IServices;
using EStore.Data.Models;
using EStore.Data.Repositories;

namespace EStore.Business.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateMemberAsync(CreateMemberDTO memberDTO)
        {
            Member member = _mapper.Map<Member>(memberDTO);
            return await _repository.CreateMemberAsync(member);
        }

        public Task<bool> DeleteMemberAsync(int id)
        {
            return _repository.DeleteMemberAsync(id);
        }

        public async Task<MemberDTO> GetMemberByIdAsync(int id)
        {
            Member member = await _repository.GetByIdAsync(id);
            return _mapper.Map<MemberDTO>(member);
        }

        public async Task<IList<MemberDTO>> GetMembersAsync()
        {
            IList<Member> members = await _repository.GetAllAsync();
            return _mapper.Map<IList<MemberDTO>>(members);
        }

        public async Task<bool> UpdateMemberAsync(MemberDTO memberDTO)
        {
            Member member = _mapper.Map<Member>(memberDTO);
            return await _repository.UpdateMemberAsync(member);
        }
    }
}