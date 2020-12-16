﻿using System.Collections.Generic;
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
            {
                return Ok(memberRole);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MemberRoleReadDto> Add(MemberRoleCreateDto memberRoleCreateDto)
        {
            if (memberRoleCreateDto == null)
            {
                return BadRequest(new { Message = "Member role cannot be empty" });
            }
            var memberRole = _service.Add(memberRoleCreateDto);
            return CreatedAtAction(nameof(GetById), new { Id = memberRole.Id }, memberRole);
        }

        [HttpPut]
        public ActionResult<MemberRoleReadDto> Update(MemberRoleUpdateDto memberRoleUpdateDto)
        {
            if (memberRoleUpdateDto == null)
            {
                return BadRequest(new { Message = "Member role cannot be empty" });
            }
            return Ok(_service.Update(memberRoleUpdateDto));
        }

        /*private readonly IMemberRoleService _memberRoleService;

        public MemberRolesController(IMemberRoleService memberRoleService)
        {
            _memberRoleService = memberRoleService;
        }

        //GET: Get list of members with role(s)
        [HttpGet("members")]
        public ActionResult<IEnumerable<MemberRoleReadDto>> GetAllMembersByRoleIds([FromQuery] List<byte> roles) // MemberReadDto
        {
            return Ok(_memberRoleService.GetAllMembersByRoleIds(roles));
        }

        //GET: Get list of roles of a member
        [HttpGet("member/{id}")]
        public ActionResult<IEnumerable<MemberRoleReadDto>> GetAllRolesByMemberId(int id) // RoleReadDto
        {
            return Ok(_memberRoleService.GetAllRolesByMemberId(id));
        }


        //GET: Get member role by id
        [HttpGet("{id}", Name = "GetMemberRoleById")]
        public ActionResult<MemberRoleReadDto> GetMemberRoleById(int id)
        {
            var memberRole = _memberRoleService.GetMemberRoleById(id);
            if (memberRole != null)
            {
                return Ok(memberRole);
            }
            return NotFound();
        }

        //POST: Add member role
        [HttpPost]
        public ActionResult<MemberRoleReadDto> AddMemberRole(MemberRoleCreateDto memberRoleCreateDto)
        {
            var memberRoleReadDto = _memberRoleService.AddMemberRole(memberRoleCreateDto);

            return CreatedAtRoute(nameof(GetMemberRoleById), new { Id = memberRoleReadDto.Id }, memberRoleReadDto);
        }

        //PUT: Update member role
        [HttpPut("{id}")]
        public ActionResult UpdateMemberRole(int id, MemberRoleUpdateDto memberRoleUpdateDto)
        {
            var memberRole = _memberRoleService.GetMemberRoleById(id);
            if (memberRole == null)
            {
                return NotFound();
            }
           
            _memberRoleService.UpdateMemberRole(id, memberRoleUpdateDto);

            return NoContent();
        } */
    }
}
