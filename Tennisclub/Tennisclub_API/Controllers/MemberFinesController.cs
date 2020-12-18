using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.MemberFineServices;
using Tennisclub_Common.MemberFineDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberFinesController : ControllerBase
    {
        private readonly IMemberFineService _service;

        public MemberFinesController(IMemberFineService service)
        {
            _service = service;
        }

        [HttpGet("bymember/{id}")]
        public ActionResult<IEnumerable<MemberFineReadDto>> GetAllByMember(int id, [FromQuery] DateTime? handoutDate, DateTime? paymentDate)
        {
            try
            {
                return Ok(_service.GetAllByMember(id, handoutDate, paymentDate));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpGet("{id}")]
        public ActionResult<MemberFineReadDto> GetById(int id)
        {
            try
            {
                var memberFine = _service.GetById(id);

                if (memberFine != null)
                    return Ok(memberFine);

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }

        [HttpPost]
        public ActionResult<MemberFineReadDto> Add(MemberFineCreateDto memberFineCreateDto)
        {
            try
            {
                if (memberFineCreateDto == null)
                    return BadRequest(new { Message = "Member fine cannot be empty" });

                var memberFine = _service.Add(memberFineCreateDto);
                return CreatedAtAction(nameof(GetById), new { Id = memberFine.Id }, memberFine);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPut]
        public ActionResult<MemberFineReadDto> Update(MemberFineUpdateDto memberFineUpdateDto)
        {
            try
            {
                if (memberFineUpdateDto == null)
                    return BadRequest(new { Message = "Member fine cannot be empty" });

                return Ok(_service.Update(memberFineUpdateDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }      
    }
}
