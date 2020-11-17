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
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        //GET: Get all filtered members
        [HttpGet]
        public ActionResult<IEnumerable<MemberReadDto>> GetAllFilteredMembers([FromQuery] string federationNr, [FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string zipCode, [FromQuery] string city)
        {
            return Ok(_memberService.GetAllActiveMembersFiltered(federationNr, firstName, lastName, zipCode, city));            
        }

        //GET: Get all filtered members
        [HttpGet("inactive")]
        public ActionResult<IEnumerable<MemberReadDto>> GetAllFilteredInActiveMembers([FromQuery] string federationNr, [FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string zipCode, [FromQuery] string city)
        {
            return Ok(_memberService.GetAllInActiveMembersFiltered(federationNr, firstName, lastName, zipCode, city));
        }

        //GET: Get member by id
        [HttpGet("{id}", Name = "GetMemberById")]
        public ActionResult<MemberReadDto> GetMemberById(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member != null)
            {
                return Ok(member);
            }
            return NotFound();
        }

        //POST: Add member
        [HttpPost]
        public ActionResult<MemberReadDto> AddMember(MemberCreateDto memberCreateDto)
        {
            var memberReadDto = _memberService.AddMember(memberCreateDto);

            return CreatedAtRoute(nameof(GetMemberById), new { Id = memberReadDto.Id }, memberReadDto);
        }

        //PUT: Update member
        [HttpPut("{id}")]
        public ActionResult UpdateMember(int id, MemberUpdateDto memberUpdateDto)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
           
            _memberService.UpdateMember(id, memberUpdateDto);

            return NoContent();
        }

        //DELETE: Delete member
        [HttpDelete("{id}")]
        public ActionResult SetMemberNotActive(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }

            _memberService.SetMemberNotActive(id);

            return NoContent();
        }

        /*//GET: Get all filtered members
        [HttpGet]
        public ActionResult<IEnumerable<MemberReadDto>> GetAllFilteredMembers([FromQuery] string federationNr, [FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string zipCode, [FromQuery] string city)
        {
            return Ok(_memberService.GetAllMembersFiltered(federationNr, firstName, lastName, zipCode, city));
            //return Ok(_mapper.Map<IEnumerable<MemberReadDto>>(_memberService.GetAllMembersFiltered(federationNr, firstName, lastName, zipCode, city)));
        }

        //GET: Get member by id
        [HttpGet("{id}", Name = "GetMemberById")]
        public ActionResult<MemberReadDto> GetMemberById(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member != null)
            {
                return Ok(_mapper.Map<MemberReadDto>(member));
            }
            return NotFound();
        }

        //POST: Add member
        [HttpPost]
        public ActionResult<MemberReadDto> AddMember(MemberCreateDto memberCreateDto)
        {            
            var memberToCreate = _mapper.Map<Member>(memberCreateDto);
            _memberService.AddMember(memberToCreate);

            var memberReadDto = _mapper.Map<MemberReadDto>(memberToCreate);
            return CreatedAtRoute(nameof(GetMemberById), new { Id = memberReadDto.Id }, memberReadDto);
        }

        //PUT: Update member
        [HttpPut("{id}")]
        public ActionResult UpdateMember(int id, MemberUpdateDto memberUpdateDto)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }

            _mapper.Map(memberUpdateDto, member);
            _memberService.UpdateMember(member);

            return NoContent();
        }*/

        //NIET EFFECTIEF VERWIJDEREN VAN MEMBER
        /*//PUT: Set member unactive
        [HttpPut("{id}")]
        public ActionResult SetMemberInactive(int id)
        {
            if (_repository.GetById(id) == null)
            {
                return NotFound();
            }

            _repository.SetMemberInactive(id);
            _repository.SaveChanges();
            return NoContent();
        }*/
    }
}
