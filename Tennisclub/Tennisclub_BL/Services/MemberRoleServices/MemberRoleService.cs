using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_DAL.Repositories.MemberRoleRepositories;

namespace Tennisclub_BL.Services.MemberRoleServices
{
    public class MemberRoleService : IMemberRoleService
    {
        private readonly IMemberRoleRepository _repository;

        public MemberRoleService(IMemberRoleRepository repository)
        {
            _repository = repository;
        }       

        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByMember(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetAllMemberRolesByMemberInlineQuery(id);

            //return _repository.GetAll(filter : memberRole => memberRole.MemberId == id,
            //    orderBy: null,
            //    includeProperties: x => x.Role);
        }

        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByRoles(List<byte> roles)
        {
            return _repository.GetAll(filter: memberRole => roles.Contains(memberRole.RoleId), 
                orderBy: null,
                x => x.Member, x => x.Role );           
        }

        public MemberRoleReadDto GetById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetById(id);
        }

        public MemberRoleReadDto Add(MemberRoleCreateDto memberRoleCreateDto)
        {
            var list = _repository.GetAll(memberRole => memberRole.MemberId == memberRoleCreateDto.MemberId 
            && memberRole.RoleId == memberRoleCreateDto.RoleId 
            && memberRole.StartDate == memberRoleCreateDto.StartDate && memberRole.EndDate == null);

            if (list.Count() != 0)
                throw new ArgumentException($"The combination of member, role, start date and end date must be unique");

            return _repository.Add(memberRoleCreateDto);
        }

        public MemberRoleReadDto Update(MemberRoleUpdateDto memberRoleUpdateDto)
        {
            var memberRole = GetById(memberRoleUpdateDto.Id);
            var list = _repository.GetAll(oldmemberRole => oldmemberRole.MemberId == memberRole.MemberId
            && oldmemberRole.RoleId == memberRole.RoleId
            && oldmemberRole.StartDate == memberRole.StartDate && oldmemberRole.EndDate == memberRoleUpdateDto.EndDate);           

            if (memberRole.EndDate != null)
                throw new Exception("Can't update this member role");

            if (list.Count() != 0)
                throw new ArgumentException($"The combination of member, role, start date and end date must be unique");

            if (memberRoleUpdateDto.EndDate < memberRole.StartDate)
                throw new Exception("End date must be greater than start date");

            return _repository.Update(memberRoleUpdateDto);
        }       
    }
}
