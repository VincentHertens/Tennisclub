using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.MemberRoleRepositories
{
    public class MemberRoleRepository : GenericRepository<MemberRole, MemberRoleReadDto, MemberRoleCreateDto, MemberRoleUpdateDto, int>, IMemberRoleRepository
    {
        public MemberRoleRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public override MemberRoleReadDto Update(MemberRoleUpdateDto updateDto)
        {
            var memberRole = _dbSet.Find(updateDto.Id);
            if (memberRole != null && memberRole.EndDate == null)
            {
                if (updateDto.EndDate >= memberRole.StartDate)
                {
                    memberRole.EndDate = updateDto.EndDate;
                    _dbSet.Update(memberRole);
                    SaveChanges();
                }
                return null;               
            }
            //TODO: Error geven als al ingevuld
            return null;
        }
    }
}
