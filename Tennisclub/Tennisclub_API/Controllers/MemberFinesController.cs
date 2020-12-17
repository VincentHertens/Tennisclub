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
            return Ok(_service.GetAllByMember(id, handoutDate, paymentDate));
        }

        [HttpGet("{id}")]
        public ActionResult<MemberFineReadDto> GetById(int id)
        {
            var memberFine = _service.GetById(id);

            if (memberFine != null)
                return Ok(memberFine);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<MemberFineReadDto> Add(MemberFineCreateDto memberFineCreateDto)
        {
            if (memberFineCreateDto == null)
                return BadRequest(new { Message = "Member fine cannot be empty" });

            var memberFine = _service.Add(memberFineCreateDto);
            return CreatedAtAction(nameof(GetById), new { Id = memberFine.Id }, memberFine);
        }

        [HttpPut]
        public ActionResult<MemberFineReadDto> Update(MemberFineUpdateDto memberFineUpdateDto)
        {
            if (memberFineUpdateDto == null)
                return BadRequest(new { Message = "Member fine cannot be empty" });

            return Ok(_service.Update(memberFineUpdateDto));
        }      
    }
}
