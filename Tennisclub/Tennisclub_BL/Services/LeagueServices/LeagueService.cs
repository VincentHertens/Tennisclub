using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.LeagueDTO;
using Tennisclub_DAL.Repositories.LeagueRepositories;

namespace Tennisclub_BL.Services.LeagueServices
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _repository;

        public LeagueService(ILeagueRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LeagueReadDto> GetAllLeagues()
        {
            return _repository.GetAll();
        }
    }
}
