﻿using AutoMapper;
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
            if (memberDTO.Password != memberDTO.ConfirmPassword)
            {
                throw new Exception("Passwords do not match");
            }
            
            Member member = _mapper.Map<Member>(memberDTO);
            return await _repository.CreateMember(member);
        }

        public Task<bool> DeleteMember(int id)
        {
            return _repository.DeleteMember(id);
        }

        public async Task<(IEnumerable<MemberDTO> membersDTO, int totalPage)> GetMembers(int pageNumber, int pageSize)
        {
            var (members, totalPage) = await _repository.GetMembers(pageNumber, pageSize);
            IEnumerable<MemberDTO> membersDTO = _mapper.Map<IList<MemberDTO>>(members);
            return (membersDTO, totalPage);
        }

        public async Task<MemberDTO?> GetMemberById(int id)
        {
            Member? member = await _repository.GetMemberById(id);
            if (member == null)
            {
                return null;
            }
            return _mapper.Map<MemberDTO>(member);
        }

        public async Task<bool> UpdateMember(MemberDTO memberDTO)
        {
            Member member = _mapper.Map<Member>(memberDTO);
            return await _repository.UpdateMember(member);
        }

        public async Task<List<MemberDTO>> GetAllMembersAsync()
        {
            var members = await _repository.GetAllAsync();
            return _mapper.Map<List<MemberDTO>>(members);
        }
    }
}