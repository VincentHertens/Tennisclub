using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.OldRepositories
{
    public class LeagueRepository : BaseRepository<League>, ILeagueRepository
    {
        public LeagueRepository(TennisclubContext context) : base(context)
        {

        }
      
        // Toekomstige methoden
    }
}
