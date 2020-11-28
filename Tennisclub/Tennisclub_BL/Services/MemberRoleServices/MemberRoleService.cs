using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Repositories.MemberRoleRepositories;

namespace Tennisclub_BL.Services.MemberRoleServices
{
    public class MemberRoleService : IMemberRoleService
    {
        private readonly IMemberRoleRepository _repository;

        public MemberRoleService(IMemberRoleRepository repository)
        {
            _repository = repository;
        }


    }
}
