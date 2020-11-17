using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Data;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public class MemberRoleService : IMemberRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
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
        }

        /* public IEnumerable<Member> GetAllMembersByRoleIds(List<byte> roles) // MemberRole
         {
             return _unitOfWork.MemberRoles.GetAllMembersByRoleIds(roles);
         }

         public IEnumerable<Role> GetAllRolesByMemberId(int id) // MemberRole
         {
             return _unitOfWork.MemberRoles.GetAllRolesByMemberId(id);
         }

         public MemberRole GetMemberRoleById(int id)
         {
             return _unitOfWork.MemberRoles.GetById(id);
         }

         public void AddMemberRole(MemberRole memberRole)
         {
             _unitOfWork.MemberRoles.Add(memberRole);
             _unitOfWork.Commit();
         }

         public void UpdateMemberRole(MemberRole memberRole)
         {
             _unitOfWork.MemberRoles.Update(memberRole);
             _unitOfWork.Commit();
         }     */
    }
}
