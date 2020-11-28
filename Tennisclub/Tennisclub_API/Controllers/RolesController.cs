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
        public IEnumerable<RoleReadDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public RoleReadDto Add(RoleCreateDto roleCreateDto)
        {
            return _service.Add(roleCreateDto);
        }

        [HttpPut]
        public RoleReadDto Update(RoleUpdateDto roleUpdateDto)
        {
            return _service.Update(roleUpdateDto);
        }

        /*private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        //GET: Get all roles
        [HttpGet]
        public ActionResult<IEnumerable<RoleReadDto>> GetAllRoles()
        {
            return Ok(_roleService.GetAllRoles());
        }

        //GET: Get role by id
        [HttpGet("{id}", Name = "GetRoleById")]
        public ActionResult<RoleReadDto> GetRoleById(byte id)
        {
            var role = _roleService.GetRoleById(id);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }

        //POST: Add role
        [HttpPost]
        public ActionResult<RoleReadDto> AddRole(RoleCreateDto roleCreateDto)
        {
            var roleReadDto = _roleService.AddRole(roleCreateDto);

            return CreatedAtRoute(nameof(GetRoleById), new { Id = roleReadDto.Id }, roleReadDto);           
        }

        //PUT: Update role
        [HttpPut("{id}")]
        public ActionResult UpdateRole(byte id, RoleUpdateDto roleUpdateDto)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
           
            _roleService.UpdateRole(id, roleUpdateDto);

            return NoContent();
        } */
    }
}
