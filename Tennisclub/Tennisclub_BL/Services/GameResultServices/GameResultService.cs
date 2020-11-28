using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Repositories.GameResultRepositories;

namespace Tennisclub_BL.Services.GameResultServices
{
    public class GameResultService : IGameResultService
    {
        private readonly IGameResultRepository _repository;

        public GameResultService(IGameResultRepository repository)
        {
            _repository = repository;
        }


    }
}
