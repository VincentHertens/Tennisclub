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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

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
        }

        /*//GET: Get all roles
        [HttpGet]
        public ActionResult<IEnumerable<RoleReadDto>> GetAllRoles()
        {
            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(_roleService.GetAllRoles()));
        }

        //GET: Get role by id
        [HttpGet("{id}", Name = "GetRoleById")]
        public ActionResult<RoleReadDto> GetRoleById(byte id)
        {
            var role = _roleService.GetRoleById(id);
            if (role != null)
            {
                return Ok(_mapper.Map<RoleReadDto>(role));
            }
            return NotFound();
        }

        //POST: Add role
        [HttpPost]
        public ActionResult<RoleReadDto> AddRole(RoleCreateDto roleCreateDto)
        {
            var roleToCreate = _mapper.Map<Role>(roleCreateDto);
            _roleService.AddRole(roleToCreate);

            var roleReadDto = _mapper.Map<RoleReadDto>(roleToCreate);
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

            _mapper.Map(roleUpdateDto, role);
            _roleService.UpdateRole(role);

            return NoContent();
        }*/
    }
}
