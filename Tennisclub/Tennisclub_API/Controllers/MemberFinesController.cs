using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_Business_Layer.Services;
using Tennisclub_Mapping.Dtos;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberFinesController : ControllerBase
    {
        private readonly IMemberFineService _memberFineService;

        public MemberFinesController(IMemberFineService memberFineService)
        {
            _memberFineService = memberFineService;
        }

        //GET: Get all member fines filtered
        [HttpGet]
        public ActionResult<IEnumerable<MemberFineReadDto>> GetAllMemberFinesFiltered([FromQuery] DateTime? handoutDate, [FromQuery] DateTime? paymentDate)
        {
            return Ok(_memberFineService.GetAllMemberFinesFiltered(handoutDate, paymentDate));
        }

        //GET: Get all filtered member fines by member 
        [HttpGet("member/{id}")]
        public ActionResult<IEnumerable<MemberFineReadDto>> GetAllMemberFinesByMemberIdFiltered(int id, [FromQuery] DateTime? handoutDate, [FromQuery] DateTime? paymentDate)
        {
            return Ok(_memberFineService.GetAllMemberFinesByMemberIdFiltered(id, handoutDate, paymentDate));
        }

        //GET: Get member fine by id
        [HttpGet("{id}", Name = "GetMemberFineById")]
        public ActionResult<MemberFineReadDto> GetMemberFineById(int id)
        {
            var memberFine = _memberFineService.GetMemberFineById(id);
            if (memberFine != null)
            {
                return Ok(memberFine);
            }
            return NotFound();
        }

        //POST: Add member fine
        [HttpPost]
        public ActionResult<MemberFineReadDto> AddMemberFine(MemberFineCreateDto memberFineCreateDto)
        {
            var memberFineReadDto = _memberFineService.AddMemberFine(memberFineCreateDto);

            return CreatedAtRoute(nameof(GetMemberFineById), new { Id = memberFineReadDto.Id }, memberFineReadDto);
        }

        //PUT: Update member fine
        [HttpPut("{id}")]
        public ActionResult UpdateMemberFine(int id, MemberFineUpdateDto memberFineUpdateDto)
        {
            var memberFine = _memberFineService.GetMemberFineById(id);
            if (memberFine == null)
            {
                return NotFound();
            }

            if (memberFine.PaymentDate != null)
            {
                return BadRequest();
            }

            _memberFineService.UpdateMemberFine(id, memberFineUpdateDto);

            return NoContent();
        }

        /*//GET: Get all member fines filtered
        [HttpGet]
        public ActionResult<IEnumerable<MemberFineReadDto>> GetAllMemberFinesFiltered([FromQuery] DateTime? handoutDate, [FromQuery] DateTime? paymentDate)
        {
            return Ok(_mapper.Map<IEnumerable<MemberFineReadDto>>(_memberFineService.GetAllMemberFinesFiltered(handoutDate, paymentDate)));
        }

        //GET: Get all filtered member fines by member 
        [HttpGet("member/{id}")]
        public ActionResult<IEnumerable<MemberFineReadDto>> GetAllMemberFinesByMemberIdFiltered(int id, [FromQuery] DateTime? handoutDate, [FromQuery] DateTime? paymentDate)
        {
            return Ok(_mapper.Map<IEnumerable<MemberFineReadDto>>(_memberFineService.GetAllMemberFinesByMemberIdFiltered(id, handoutDate, paymentDate)));
        }

        //GET: Get member fine by id
        [HttpGet("{id}", Name = "GetMemberFineById")]
        public ActionResult<MemberFineReadDto> GetMemberFineById(int id)
        {
            var memberFine = _memberFineService.GetMemberFineById(id);
            if (memberFine != null)
            {
                return Ok(_mapper.Map<MemberFineReadDto>(memberFine));
            }
            return NotFound();
        }

        //POST: Add member fine
        [HttpPost]
        public ActionResult<MemberFineReadDto> AddMemberFine(MemberFineCreateDto memberFineCreateDto)
        {
            var memberFineToCreate = _mapper.Map<MemberFine>(memberFineCreateDto);
            _memberFineService.AddMemberFine(memberFineToCreate);

            var memberFineReadDto = _mapper.Map<MemberFineReadDto>(memberFineToCreate);
            return CreatedAtRoute(nameof(GetMemberFineById), new { Id = memberFineReadDto .Id}, memberFineReadDto);
        }

        //PUT: Update member fine
        [HttpPut("{id}")]
        public ActionResult UpdateMemberFine(int id, MemberFineUpdateDto memberFineUpdateDto)
        {
            var memberFine = _memberFineService.GetMemberFineById(id);
            if (memberFine == null)
            {
                return NotFound();
            }

            if (memberFine.PaymentDate != null)
            {
                return BadRequest();
            }

            _mapper.Map(memberFineUpdateDto, memberFine);
            _memberFineService.UpdateMemberFine(memberFine);

            return NoContent();
        }*/
    }
}
