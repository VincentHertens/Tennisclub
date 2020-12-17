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
                return Ok(member);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<MemberReadDto> Add(MemberCreateDto memberCreateDto)
        {
            if (memberCreateDto == null)
                return BadRequest(new { Message = "Member cannot be empty" });
           
            var member = _service.Add(memberCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpPut]
        public ActionResult<MemberReadDto> Update(MemberUpdateDto memberUpdateDto)
        {
            if (memberUpdateDto == null)
                return BadRequest(new { Message = "Member cannot be empty" });
            
            return Ok(_service.Update(memberUpdateDto));
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var member = _service.GetById(id);

            if (member == null)
                return NotFound();
            
            _service.Delete(id);
            return NoContent();
        }       
    }
}
