using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public interface ILeagueService
    {
        IEnumerable<LeagueReadDto> GetAllLeagues();
        LeagueReadDto GetLeagueById(byte id);

        /*IEnumerable<League> GetAllLeagues();
        League GetLeagueById(byte id);*/
    }
}
