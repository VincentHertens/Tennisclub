using System.Collections.Generic;
using Tennisclub_Common.GenderDTO;
using Tennisclub_DAL.Repositories.GenderRepositories;

namespace Tennisclub_BL.Services.GenderServices
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repository;

        public GenderService(IGenderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GenderReadDto> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
