using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_BL.OldServices
{
    public class MemberRoleService //: IMemberRoleService
    {
       /* private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberRoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MemberRoleReadDto> GetAllMembersByRoleIds(List<byte> roles) // Member
        {
            return _mapper.Map<IEnumerable<MemberRoleReadDto>>(_unitOfWork.MemberRoles.GetAllMembersByRoleIds(roles));
        }

        public IEnumerable<MemberRoleReadDto> GetAllRolesByMemberId(int id) // Role
        {
            return _mapper.Map<IEnumerable<MemberRoleReadDto>>(_unitOfWork.MemberRoles.GetAllRolesByMemberId(id));
        }

        public MemberRoleReadDto GetMemberRoleById(int id)
        {
            return _mapper.Map<MemberRoleReadDto>(_unitOfWork.MemberRoles.GetById(id));
        }

        public MemberRoleReadDto AddMemberRole(MemberRoleCreateDto memberRole)
        {
            var memberRoleToCreate = _mapper.Map<MemberRole>(memberRole);
            _unitOfWork.MemberRoles.Add(memberRoleToCreate);
            _unitOfWork.Commit();

            var memberRoleReadDto = _mapper.Map<MemberRoleReadDto>(memberRoleToCreate);
            return memberRoleReadDto;
        }

        public void UpdateMemberRole(int id, MemberRoleUpdateDto memberRole)
        {
            var memberRoleToUpdate = _unitOfWork.MemberRoles.GetById(id);
            var updatedMemberRole = _mapper.Map(memberRole, memberRoleToUpdate);

            _unitOfWork.MemberRoles.Update(updatedMemberRole);
            _unitOfWork.Commit();
        }*/    
    }
}
