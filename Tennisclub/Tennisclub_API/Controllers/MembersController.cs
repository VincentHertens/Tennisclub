using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.MemberServices;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _service;

        public MembersController(IMemberService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<MemberReadDto> GetAll([FromQuery] string federationNr, [FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string zipCode, [FromQuery] string city)
        {
            return _service.GetAllActiveMembers(federationNr, firstName, lastName, zipCode, city);
        }

        [HttpGet("{id}")]
        public MemberReadDto GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public MemberReadDto Add(MemberCreateDto memberCreateDto)
        {
            return _service.Add(memberCreateDto);
        }

        [HttpPut]
        public MemberReadDto Update(MemberUpdateDto memberUpdateDto)
        {
            return _service.Update(memberUpdateDto);
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        /*private readonly IMemberService _memberService;

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
        }*/


    }
}
