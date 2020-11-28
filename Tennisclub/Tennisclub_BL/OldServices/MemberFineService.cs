using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberFineDTO;
using Tennisclub_DAL.Models;

namespace Tennisclub_BL.OldServices
{
    public class MemberFineService //: IMemberFineService
    {
       /* private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberFineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MemberFineReadDto> GetAllMemberFinesFiltered(DateTime? handoutDate, DateTime? paymentDate)
        {
            return _mapper.Map<IEnumerable<MemberFineReadDto>>(_unitOfWork.MemberFines.GetAllMemberFinesFiltered(handoutDate, paymentDate));
        }

        public IEnumerable<MemberFineReadDto> GetAllMemberFinesByMemberIdFiltered(int id, DateTime? handoutDate, DateTime? paymentDate)
        {
            return _mapper.Map<IEnumerable<MemberFineReadDto>>(_unitOfWork.MemberFines.GetAllMemberFinesByMemberIdFiltered(id, handoutDate, paymentDate));
        }

        public MemberFineReadDto GetMemberFineById(int id)
        {
            return _mapper.Map<MemberFineReadDto>(_unitOfWork.MemberFines.GetById(id));
        }

        public MemberFineReadDto AddMemberFine(MemberFineCreateDto memberFine)
        {
            var memberFineToCreate = _mapper.Map<MemberFine>(memberFine);
            _unitOfWork.MemberFines.Add(memberFineToCreate);
            _unitOfWork.Commit();

            var memberFineReadDto = _mapper.Map<MemberFineReadDto>(memberFineToCreate);
            return memberFineReadDto;
        }

        public void UpdateMemberFine(int id, MemberFineUpdateDto memberFine)
        {
            var memberFineToUpdate = _unitOfWork.MemberFines.GetById(id);
            var updatedMemberFine = _mapper.Map(memberFine, memberFineToUpdate);

            _unitOfWork.MemberFines.Update(updatedMemberFine);
            _unitOfWork.Commit();
        }*/     
    }
}
