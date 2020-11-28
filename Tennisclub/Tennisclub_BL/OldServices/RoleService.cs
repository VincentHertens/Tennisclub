using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_BL.OldServices
{
    public class RoleService //: IRoleService
    {
       /* private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<RoleReadDto> GetAllRoles()
        {
            return _mapper.Map<IEnumerable<RoleReadDto>>(_unitOfWork.Roles.GetAll());
        }

        public RoleReadDto GetRoleById(byte id)
        {
            return _mapper.Map<RoleReadDto>(_unitOfWork.Roles.GetById(id));
        }

        public RoleReadDto AddRole(RoleCreateDto role)
        {
            var roleToCreate = _mapper.Map<Role>(role);
            _unitOfWork.Roles.Add(roleToCreate);
            _unitOfWork.Commit();

            var memberReadDto = _mapper.Map<RoleReadDto>(roleToCreate);
            return memberReadDto;
        }

        public void UpdateRole(byte id, RoleUpdateDto role)
        {
            var roleToUpdate = _unitOfWork.Roles.GetById(id);

            var updatedRole = _mapper.Map(role, roleToUpdate);

            _unitOfWork.Roles.Update(updatedRole);
            _unitOfWork.Commit();
        }*/    
    }
}
