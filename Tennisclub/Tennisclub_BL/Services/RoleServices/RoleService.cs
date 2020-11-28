using System.Collections.Generic;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Repositories.RoleRepositories;

namespace Tennisclub_BL.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RoleReadDto> GetAll()
        {
            return _repository.GetAll();
        }

        public RoleReadDto Add(RoleCreateDto roleCreateDto)
        {
            return _repository.Add(roleCreateDto);
        }

        public RoleReadDto Update(RoleUpdateDto roleUpdateDto)
        {
            return _repository.Update(roleUpdateDto);
        }
    }
}
