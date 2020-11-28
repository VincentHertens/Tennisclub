using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        //IEnumerable<Member> GetAllMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city);

        IEnumerable<Member> GetAllActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city);
        IEnumerable<Member> GetAllInActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city);
        //IEnumerable<Member> GetAllNonActiveMembersFiltered(string federationNr, string firstName, string lastName, string zipCode, string city);

    }
}
