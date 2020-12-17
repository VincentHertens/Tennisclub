using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.LeagueDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_DAL.Repositories.LeagueRepositories
{
    public class LeagueRepository : GenericRepository<League, LeagueReadDto, object, object, byte>, ILeagueRepository
    {
        public LeagueRepository(TennisclubContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
