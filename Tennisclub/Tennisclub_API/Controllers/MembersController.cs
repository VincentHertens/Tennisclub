using System;
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
            try
            {
                var member = _service.GetById(id);

                if (member != null)
                    return Ok(member);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }        
        }

        [HttpPost]
        public ActionResult<MemberReadDto> Add(MemberCreateDto memberCreateDto)
        {
            try
            {
                if (memberCreateDto == null)
                    return BadRequest(new { Message = "Member cannot be empty" });

                var member = _service.Add(memberCreateDto);
                return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<MemberReadDto> Update(MemberUpdateDto memberUpdateDto)
        {
            try
            {
                if (memberUpdateDto == null)
                    return BadRequest(new { Message = "Member cannot be empty" });

                return Ok(_service.Update(memberUpdateDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var member = _service.GetById(id);

                if (member == null)
                    return NotFound();

                _service.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }          
        }       
    }
}
