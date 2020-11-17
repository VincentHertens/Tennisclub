using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public class MemberRoleRepository : BaseRepository<MemberRole>, IMemberRoleRepository
    {
        public MemberRoleRepository(TennisclubContext context) : base(context)
        {

        }      

        public IEnumerable<MemberRole> GetAllMembersByRoleIds(List<byte> roles) // Member
        {
            return _context.Set<MemberRole>().Where(memberRole => roles.Contains(memberRole.RoleId)).Include(c => c.Member).Include(x => x.Role).ToList(); // .Distinct()
            //return _context.Set<MemberRole>().Include(x => x.Member).Include(x => x.Role).Where(memberRole => roles.Contains(memberRole.RoleId)).ToList();
        }

        public IEnumerable<MemberRole> GetAllRolesByMemberId(int id) // Role
        {
            return _context.Set<MemberRole>().Where(memberRole => memberRole.MemberId == id).Include(c => c.Role).ToList();
            //return _context.Set<MemberRole>().Include(x => x.Member).Include(x => x.Role).Where(memberRole => memberRole.MemberId == id).ToList();
        }


    }
}
