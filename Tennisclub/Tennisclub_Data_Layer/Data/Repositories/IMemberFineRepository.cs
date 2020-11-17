using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public interface IMemberFineRepository : IBaseRepository<MemberFine>
    {
        IEnumerable<MemberFine> GetAllMemberFinesFiltered(DateTime? handoutDate, DateTime? paymentDate);
        IEnumerable<MemberFine> GetAllMemberFinesByMemberIdFiltered(int id, DateTime? handoutDate, DateTime? paymentDate);
    }
}
