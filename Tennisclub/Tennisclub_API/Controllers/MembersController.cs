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
        public ActionResult<IEnumerable<MemberReadDto>> GetAll([FromQuery] string federationNr, [FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string zipCode, [FromQuery] string city)
        {
            return Ok(_service.GetAllActiveMembers(federationNr, firstName, lastName, zipCode, city));
        }

        [HttpGet("{id}")]
        public ActionResult<MemberReadDto> GetById(int id)
        {
            var member = _service.GetById(id);
            if (member != null)
            {
                return Ok(member);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MemberReadDto> Add(MemberCreateDto memberCreateDto)
        {
            if (memberCreateDto == null)
            {
                return BadRequest(new { Message = "Member cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.FederationNr))
            {
                return BadRequest(new { Message = "FederationNr cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.FirstName))
            {
                return BadRequest(new { Message = "First name cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.LastName))
            {
                return BadRequest(new { Message = "Last name cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.Address))
            {
                return BadRequest(new { Message = "Address cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.Number))
            {
                return BadRequest(new { Message = "Number cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.Zipcode))
            {
                return BadRequest(new { Message = "ZIP code cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.City))
            {
                return BadRequest(new { Message = "City cannot be empty" });
            }
            if (string.IsNullOrEmpty(memberCreateDto.LastName))
            {
                return BadRequest(new { Message = "Last name cannot be empty" });
            }
            var member = _service.Add(memberCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpPut]
        public ActionResult<MemberReadDto> Update(MemberUpdateDto memberUpdateDto)
        {
            if (memberUpdateDto == null)
            {
                return BadRequest(new { Message = "Member cannot be empty" });
            }
            return Ok(_service.Update(memberUpdateDto));
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var member = _service.GetById(id);
            if (member == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
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
