using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.LeagueDTO;

namespace Tennisclub_BL.OldServices
{
    public interface ILeagueService
    {
        IEnumerable<LeagueReadDto> GetAllLeagues();
        LeagueReadDto GetLeagueById(byte id);

        /*IEnumerable<League> GetAllLeagues();
        League GetLeagueById(byte id);*/
    }
}
