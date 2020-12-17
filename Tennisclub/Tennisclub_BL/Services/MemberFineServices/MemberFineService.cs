using System;
using System.Collections.Generic;
using System.Linq;
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
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetAll(filter: fine => fine.MemberId == id 
            && (fine.HandoutDate == handoutDate || handoutDate == null)
            && (fine.PaymentDate == paymentDate || paymentDate == null));
        }

        public MemberFineReadDto GetById(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("Id cannot have a value less than 1");

            return _repository.GetById(id);
        }

        public MemberFineReadDto Add(MemberFineCreateDto memberFineCreateDto)
        {
            var list = _repository.GetAll(fine => fine.FineNumber == memberFineCreateDto.FineNumber);

            if (list.Count() != 0)
                throw new ArgumentException($"Fine number must be unique");

            return _repository.Add(memberFineCreateDto);
        }

        public MemberFineReadDto Update(MemberFineUpdateDto memberFineUpdateDto)
        {
            var memberFine = GetById(memberFineUpdateDto.Id);

            if (memberFine.PaymentDate != null)
                throw new Exception("Can't update this fine");

            if (memberFineUpdateDto.PaymentDate < memberFine.HandoutDate)
                throw new Exception("Payment date must be greater than the handout date");

            return _repository.Update(memberFineUpdateDto);
        }
    }
}
