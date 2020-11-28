using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.MemberRoleRepositories
{
    public class MemberRoleRepository : GenericRepository<MemberRole, MemberRoleReadDto, MemberRoleCreateDto, MemberRoleUpdateDto, int>, IMemberRoleRepository
    {
        public MemberRoleRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }


    }
}
