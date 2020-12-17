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

        public override MemberFineReadDto Update(MemberFineUpdateDto updateDto)
        {
            var memberFine = _dbSet.Find(updateDto.Id);
            if (memberFine != null && memberFine.PaymentDate == null)
            {
                if (updateDto.PaymentDate >= memberFine.HandoutDate)
                {
                    memberFine.PaymentDate = updateDto.PaymentDate;
                    _dbSet.Update(memberFine);
                    SaveChanges();
                }
                return null;
            }
            //TODO: Error geven als al ingevuld
            return null;
        }
    }
}
