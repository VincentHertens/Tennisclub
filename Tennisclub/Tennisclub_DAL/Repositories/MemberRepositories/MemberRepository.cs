using AutoMapper;
using Tennisclub_Common.MemberDTO;
using Tennisclub_DAL.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tennisclub_DAL.Repositories.MemberRepositories
{
    public class MemberRepository : GenericRepository<Member, MemberReadDto, MemberCreateDto, MemberUpdateDto, int>, IMemberRepository
    {
        public MemberRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public override void Delete(int id)
        {
            Member member = _dbSet.Find(id);
            member.Active = false;
            _dbSet.Update(member);
            SaveChanges();
        }

        public override MemberReadDto Add(MemberCreateDto createDto)
        {
            Validate(createDto.GenderId);

            return base.Add(createDto);
        }

        public override MemberReadDto Update(MemberUpdateDto updateDto)
        {              
            Validate(updateDto.GenderId);

            var entry = _context.Entry(_mapper.Map<Member>(updateDto));
            entry.Property(x => x.FederationNr).IsModified = true;
            entry.Property(x => x.FirstName).IsModified = true;
            entry.Property(x => x.LastName).IsModified = true;
            entry.Property(x => x.BirthDate).IsModified = true;
            entry.Property(x => x.GenderId).IsModified = true;
            entry.Property(x => x.Address).IsModified = true;
            entry.Property(x => x.Number).IsModified = true;
            entry.Property(x => x.Addition).IsModified = true;
            entry.Property(x => x.Zipcode).IsModified = true;
            entry.Property(x => x.City).IsModified = true;
            entry.Property(x => x.PhoneNr).IsModified = true;

            SaveChanges();
            return GetById(updateDto.Id);
        }

        private void Validate(byte genderId)
        {
            var gender = _context.Set<Gender>().Find(genderId);

            if (gender == null)
                throw new NullReferenceException("No gender with this id has been found");
        }
    }
}
