using System;
using System.Collections.Generic;
using System.Linq;
using Tennisclub_Common.RoleDTO;
using Tennisclub_DAL.Repositories.RoleRepositories;

namespace Tennisclub_BL.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private const int MAX_NAME = 20;
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RoleReadDto> GetAll()
        {
            //return _repository.GetAll();
            return _repository.GetAllRolesSP();
        }

        public RoleReadDto GetById(byte id)
        {
            return _repository.GetById(id);
        }


        public RoleReadDto Add(RoleCreateDto roleCreateDto)
        {
            var list = _repository.GetAll(role => role.Name == roleCreateDto.Name);

            if (list.Count() != 0)
                throw new ArgumentException($"Name must be unique");

            ValidateFields(roleCreateDto.Name);

            return _repository.Add(roleCreateDto);
        }

        public RoleReadDto Update(RoleUpdateDto roleUpdateDto)
        {
            var list = _repository.GetAll(role => role.Name == roleUpdateDto.Name && role.Id != roleUpdateDto.Id);

            if (list.Count() != 0)
                throw new ArgumentException($"Name must be unique");

            ValidateFields(roleUpdateDto.Name);

            return _repository.Update(roleUpdateDto);
        }

        private void ValidateFields(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME)
                throw new ArgumentException($"Name cannot be empty or more than {MAX_NAME} characters");
        }
    }
}