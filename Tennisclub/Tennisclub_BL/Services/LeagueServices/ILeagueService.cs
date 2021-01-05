using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.LeagueDTO;

namespace Tennisclub_BL.Services.LeagueServices
{
    public interface ILeagueService
    {
        IEnumerable<LeagueReadDto> GetAllLeagues();
    }
}
