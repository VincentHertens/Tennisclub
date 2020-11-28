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
        {

        }
    }
}
