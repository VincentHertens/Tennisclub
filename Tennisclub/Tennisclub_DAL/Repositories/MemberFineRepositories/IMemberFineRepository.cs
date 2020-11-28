using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberFineDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.MemberFineRepositories
{
    public interface IMemberFineRepository : IGenericRepository<MemberFine, MemberFineReadDto, MemberFineCreateDto, MemberFineUpdateDto, int>
    {

    }
}
