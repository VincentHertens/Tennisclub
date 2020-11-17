using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Models;

namespace Tennisclub_Data_Layer.Repositories
{
    public class LeagueRepository : BaseRepository<League>, ILeagueRepository
    {
        public LeagueRepository(TennisclubContext context) : base(context)
        {

        }
      
        // Toekomstige methoden
    }
}
