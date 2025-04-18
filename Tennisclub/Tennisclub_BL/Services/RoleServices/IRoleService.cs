﻿using System.Collections.Generic;
using Tennisclub_Common.RoleDTO;

namespace Tennisclub_BL.Services.RoleServices
{
    public interface IRoleService
    {
        public IEnumerable<RoleReadDto> GetAllRoles();
        public RoleReadDto GetById(byte id);
        public RoleReadDto Add(RoleCreateDto roleCreateDto);
        public RoleReadDto Update(RoleUpdateDto roleUpdateDto);
    }
}
