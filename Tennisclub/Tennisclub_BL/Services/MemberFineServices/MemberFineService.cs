using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberFineDTO;
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

        public IEnumerable<MemberFineReadDto> GetAllByMember(int id, DateTime? handoutDate, DateTime? paymentDate)
        {
            return _repository.GetAll(filter: fine => fine.MemberId == id 
            && (fine.HandoutDate == handoutDate || handoutDate == null)
            && (fine.PaymentDate == paymentDate || paymentDate == null));
        }

        public MemberFineReadDto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public MemberFineReadDto Add(MemberFineCreateDto memberFineCreateDto)
        {
            return _repository.Add(memberFineCreateDto);
        }

        public MemberFineReadDto Update(MemberFineUpdateDto memberFineUpdateDto)
        {
            return _repository.Update(memberFineUpdateDto);
        }
    }
}
