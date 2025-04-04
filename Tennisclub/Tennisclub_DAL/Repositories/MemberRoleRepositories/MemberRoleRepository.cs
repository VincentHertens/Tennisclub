﻿using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByMemberInlineQuery(int id)
        {
            var parameter = new SqlParameter("@Id", id);
            var memberRoles = _dbSet.FromSqlRaw("Select * from MemberRoles where MemberId = @Id", parameter).Include(x => x.Role).AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<MemberRoleReadDto>>(memberRoles);
        }

        public IEnumerable<MemberRoleReadDto> GetAllMemberRolesByRoles(List<byte> roles)
        {
            return GetAll(filter: memberRole => roles.Contains(memberRole.RoleId),
                orderBy: null,
                x => x.Member, x => x.Role);
        }

        public override MemberRoleReadDto Add(MemberRoleCreateDto createDto)
        {
            var member = _context.Set<Member>().Find(createDto.MemberId);
            var role = _context.Set<Role>().Find(createDto.RoleId);

            if (member == null)
                throw new NullReferenceException("No member with this id has been found");

            if (role == null)
                throw new NullReferenceException("No role with this id has been found");

            return base.Add(createDto);
        }

        public override MemberRoleReadDto Update(MemberRoleUpdateDto updateDto)
        {
            var memberRole = _dbSet.Find(updateDto.Id);          
            memberRole.EndDate = updateDto.EndDate;
            _dbSet.Update(memberRole);
            SaveChanges();
            return GetById(memberRole.Id);
        }
    }
}
