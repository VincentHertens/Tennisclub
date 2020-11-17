using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Repositories;

namespace Tennisclub_Data_Layer.Data
{
    public interface IUnitOfWork
    {
        IMemberRepository Members { get; }
        IGenderRepository Genders { get; }
        IGameRepository Games { get; }
        IGameResultRepository GameResults { get; }
        ILeagueRepository Leagues { get; }
        IMemberRoleRepository MemberRoles { get; }
        IRoleRepository Roles { get; }
        IMemberFineRepository MemberFines { get; }

        bool Commit();
    }
}
