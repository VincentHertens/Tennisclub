using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_DAL.Repositories.MemberFineRepositories;

namespace Tennisclub_BL.Services.MemberFineServices
{
    public class MemberFineService : IMemberFineService
    {
        private readonly IMemberFineRepository _repository;

        public MemberFineService(IMemberFineRepository repository)
        {
            _repository = repository;
        }


    }
}
