using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.RoleDTO;

namespace Tennisclub_BL.OldServices
{
    public interface IRoleService
    {
        IEnumerable<RoleReadDto> GetAllRoles();
        RoleReadDto GetRoleById(byte id);
        RoleReadDto AddRole(RoleCreateDto role);
        void UpdateRole(byte id, RoleUpdateDto role);

        /* IEnumerable<Role> GetAllRoles();
         Role GetRoleById(byte id);
         void AddRole(Role role);
         void UpdateRole(Role role);*/
    }
}
