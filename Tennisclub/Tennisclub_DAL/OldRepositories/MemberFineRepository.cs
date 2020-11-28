using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public class MemberFineRepository : BaseRepository<MemberFine>, IMemberFineRepository
    {
        public MemberFineRepository(TennisclubContext context) : base(context)
        {

        }

        public IEnumerable<MemberFine> GetAllMemberFinesFiltered(DateTime? handoutDate, DateTime? paymentDate)
        {
            return _context.Set<MemberFine>().Include(x => x.Member).Where(memberFine => (memberFine.HandoutDate == handoutDate || handoutDate == null)
            && (memberFine.PaymentDate == paymentDate || paymentDate == null)).ToList();    
        }

        public IEnumerable<MemberFine> GetAllMemberFinesByMemberIdFiltered(int id, DateTime? handoutDate, DateTime? paymentDate)
        {
            return _context.Set<MemberFine>().Where(memberFine => memberFine.MemberId == id 
            && (memberFine.HandoutDate == handoutDate || handoutDate == null)
            && (memberFine.PaymentDate == paymentDate || paymentDate == null)).ToList();
        }
    }
}
