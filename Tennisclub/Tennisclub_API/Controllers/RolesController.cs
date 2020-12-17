using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tennisclub_BL.Services.RoleServices;
using Tennisclub_Common.RoleDTO;

namespace Tennisclub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleReadDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<RoleReadDto> GetById(byte id)
        {
            var role = _service.GetById(id);

            if (role != null)
                return Ok(_service.GetById(id));

            return NotFound();
        }

        [HttpPost]
        public ActionResult<RoleReadDto> Add(RoleCreateDto roleCreateDto)
        {
            if (roleCreateDto == null)
                return BadRequest("Role cannot be null");

            var role = _service.Add(roleCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPut]
        public ActionResult<RoleReadDto> Update(RoleUpdateDto roleUpdateDto)
        {
            if (roleUpdateDto == null)
                return BadRequest(new { Message = "Role cannot be empty" });

            return Ok(_service.Update(roleUpdateDto));
        }       
    }
}
