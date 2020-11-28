using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(TennisclubContext context) : base(context)
        {

        }

        public IEnumerable<Member> GetAllActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city)
        {
            return _context.Members.Include(x => x.Gender).Where(member => member.Active == true
            && (member.FederationNr == federationNr || federationNr == null)
            && (member.FirstName == firstName || firstName == null)
            && (member.LastName == lastName || lastName == null)
            && (member.Zipcode == zipCode || zipCode == null)
            && (member.City == city || city == null)).ToList();
        }

        public IEnumerable<Member> GetAllInActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city)
        {
            return _context.Members.Include(x => x.Gender).Where(member => member.Active == false
            && (member.FederationNr == federationNr || federationNr == null)
            && (member.FirstName == firstName || firstName == null)
            && (member.LastName == lastName || lastName == null)
            && (member.Zipcode == zipCode || zipCode == null)
            && (member.City == city || city == null)).ToList();
        }

        /*public IEnumerable<Member> GetAllMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city) //_context.Members??????
        {
            return _context.Set<Member>().Include(x => x.Gender).Where(member => (member.FederationNr == federationNr || federationNr == null)
            && (member.FirstName == firstName || firstName == null) 
            && (member.LastName == lastName || lastName == null)
            && (member.Zipcode == zipCode || zipCode == null)
            && (member.City == city || city == null)).ToList();
        }*/

        /*public IEnumerable<Member> GetAllNonActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city)
        {
            return _context.Members.Include(x => x.Gender).Where(member => member.Active == false
            && (member.FederationNr == federationNr || federationNr == null)
            && (member.FirstName == firstName || firstName == null)
            && (member.LastName == lastName || lastName == null)
            && (member.Zipcode == zipCode || zipCode == null)
            && (member.City == city || city == null)).ToList();
        }*/
    }
}
