using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public interface IMemberFineRepository : IBaseRepository<MemberFine>
    {
        IEnumerable<MemberFine> GetAllMemberFinesFiltered(DateTime? handoutDate, DateTime? paymentDate);
        IEnumerable<MemberFine> GetAllMemberFinesByMemberIdFiltered(int id, DateTime? handoutDate, DateTime? paymentDate);
    }
}
