using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberFineDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.MemberFineRepositories
{
    public class MemberFineRepository : GenericRepository<MemberFine, MemberFineReadDto, MemberFineCreateDto, MemberFineUpdateDto, int>, IMemberFineRepository
    {
        public MemberFineRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }

        public override MemberFineReadDto Add(MemberFineCreateDto createDto)
        {
            var member = _context.Set<Member>().Find(createDto.MemberId);

            if (member == null)
                throw new NullReferenceException("No member with this id has been found");

            return base.Add(createDto);
        }

        public override MemberFineReadDto Update(MemberFineUpdateDto updateDto)
        {
            var memberFine = _dbSet.Find(updateDto.Id);
            memberFine.PaymentDate = updateDto.PaymentDate;
            _dbSet.Update(memberFine);
            SaveChanges();
            return GetById(memberFine.Id);
        }
    }
}
