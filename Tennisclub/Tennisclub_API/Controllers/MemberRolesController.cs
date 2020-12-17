using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.MemberRoleServices;
using Tennisclub_Common.MemberRoleDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberRolesController : ControllerBase
    {
        private readonly IMemberRoleService _service;

        public MemberRolesController(IMemberRoleService service)
        {
            _service = service;
        }

        [HttpGet("byroles")]
        public ActionResult<IEnumerable<MemberRoleReadDto>> GetAllMemberRolesByRoles([FromQuery] List<byte> roles)
        {
            return Ok(_service.GetAllMemberRolesByRoles(roles));
        }

        [HttpGet("bymember/{id}")]
        public ActionResult<IEnumerable<MemberRoleReadDto>> GetAllMemberRolesByMember(int id)
        {
            return Ok(_service.GetAllMemberRolesByMember(id));
        }

        [HttpGet("{id}")]
        public ActionResult<MemberRoleReadDto> GetById(int id)
        {
            var memberRole = _service.GetById(id);

            if (memberRole != null)
                return Ok(memberRole);

            return NotFound();
        }

        [HttpPost]
        public ActionResult<MemberRoleReadDto> Add(MemberRoleCreateDto memberRoleCreateDto)
        {
            if (memberRoleCreateDto == null)
                return BadRequest(new { Message = "Member role cannot be empty" });
            
            var memberRole = _service.Add(memberRoleCreateDto);
            return CreatedAtAction(nameof(GetById), new { Id = memberRole.Id }, memberRole);
        }

        [HttpPut]
        public ActionResult<MemberRoleReadDto> Update(MemberRoleUpdateDto memberRoleUpdateDto)
        {
            if (memberRoleUpdateDto == null)
                return BadRequest(new { Message = "Member role cannot be empty" });
            
            return Ok(_service.Update(memberRoleUpdateDto));
        }       
    }
}
