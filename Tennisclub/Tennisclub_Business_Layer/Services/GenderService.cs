using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Data_Layer.Data;
using Tennisclub_Data_Layer.Models;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_Business_Layer.Services
{
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GenderReadDto> GetAllGenders()
        {
            return _mapper.Map<IEnumerable<GenderReadDto>>(_unitOfWork.Genders.GetAll());
        }

        public GenderReadDto GetGenderById(byte id)
        {
            return _mapper.Map<GenderReadDto>(_unitOfWork.Genders.GetById(id));
        }

        /* public IEnumerable<Gender> GetAllGenders()
         {
             return _unitOfWork.Genders.GetAll();
         }

         public Gender GetGenderById(byte id)
         {
             return _unitOfWork.Genders.GetById(id);
         }*/
    }
}
