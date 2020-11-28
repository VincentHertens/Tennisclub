using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.LeagueDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.LeagueRepositories
{
    public interface ILeagueRepository : IGenericRepository<League, LeagueReadDto, object, object, byte>
    {
    }
}
