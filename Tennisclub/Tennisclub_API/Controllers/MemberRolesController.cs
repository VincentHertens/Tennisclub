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
    public class MemberRolesController : ControllerBase
    {
        private readonly IMemberRoleService _memberRoleService;

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
        }

        /*//GET: Get list of members with role(s)
        [HttpGet("members")]
        public ActionResult<IEnumerable<MemberReadDto>> GetAllMembersByRoleIds([FromQuery] List<byte> roles) // MemberRoleReadDto
        {
            return Ok(_mapper.Map<IEnumerable<MemberReadDto>>(_memberRoleService.GetAllMembersByRoleIds(roles)));
        }

        //GET: Get list of roles of a member
        [HttpGet("member/{id}")]
        public ActionResult<IEnumerable<RoleReadDto>> GetAllRolesByMemberId(int id) // MemberRoleReadDto
        {
            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(_memberRoleService.GetAllRolesByMemberId(id)));
        }


        //GET: Get member role by id
        [HttpGet("{id}", Name = "GetMemberRoleById")]
        public ActionResult<MemberRoleReadDto> GetMemberRoleById(int id)
        {
            var memberRole = _memberRoleService.GetMemberRoleById(id);
            if (memberRole != null)
            {
                return Ok(_mapper.Map<MemberRoleReadDto>(memberRole));
            }
            return NotFound();
        }

        //POST: Add member role
        [HttpPost]
        public ActionResult<MemberRoleReadDto> AddMemberRole(MemberRoleCreateDto memberRoleCreateDto)
        {
            var memberRoleToCreate = _mapper.Map<MemberRole>(memberRoleCreateDto);
            _memberRoleService.AddMemberRole(memberRoleToCreate);

            var memberRoleReadDto = _mapper.Map<MemberRoleReadDto>(memberRoleToCreate);
            return CreatedAtRoute(nameof(GetMemberRoleById), new { Id = memberRoleReadDto.Id}, memberRoleReadDto);
        }

        //PUT: Patch member role
        [HttpPut("{id}")]
        public ActionResult UpdateMemberRole(int id, MemberRoleUpdateDto memberRoleUpdateDto)
        {
            var memberRole = _memberRoleService.GetMemberRoleById(id);
            if (memberRole == null)
            {
                return NotFound();
            }

            _mapper.Map(memberRoleUpdateDto, memberRole);
            _memberRoleService.UpdateMemberRole(memberRole);

            return NoContent();
        }*/
    }
}
