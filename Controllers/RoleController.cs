using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            this._roleRepository = roleRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("/get/roles")]
        [Authorize]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var roles = await this._roleRepository.GetAllAsync();
            var rolesDTO = this._mapper.Map<IEnumerable<RoleDTO>>(roles);
            return Ok(rolesDTO);
        }

        [HttpGet]
        [Route("/get/role/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetRoleByIdAsync(Guid id)
        {
            var role = await this._roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            var roleDTO = this._mapper.Map<RoleDTO>(role);
            return Ok(roleDTO);
        }

        [HttpPost]
        [Route("/create/role")]
        [Authorize]
        public async Task<IActionResult> AddRoleAsync(AddRoleDTO addRoleDTO)
        {
            var role = this._mapper.Map<Role>(addRoleDTO);
            var exist = await this._roleRepository.GetByIdAsync(role.UserId);
            if (exist != null)
            {
                return BadRequest("Role already exists");
            }

            var result = await this._roleRepository.AddAsync(role);
            if(!result)
            {
                return BadRequest("Role not created");
            }

            return Ok("Role created");
        }

        [HttpPut]
        [Route("/update/role/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateRoleAsync(Guid id, UpdateRoleDTO updateRoleDTO)
        {
            var exist = await this._roleRepository.GetByIdAsync(id);
            if (exist != null)
            {
                return BadRequest("Role updated");
            }

            var role = this._mapper.Map<Role>(updateRoleDTO);
            var result = await this._roleRepository.UpdateAsync(id, role);
            if(!result)
            {
                return BadRequest("Role not updated");
            }

            return Ok("Role updated");
        }

        [HttpDelete]
        [Route("/delete/role/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoleAsync(Guid id)
        {
            var exist = await this._roleRepository.GetByIdAsync(id);
            if(exist == null)
            {
                return BadRequest("Role not founbd");
            }

            var result = await this._roleRepository.DeleteAsync(exist);
            if(!result)
            {
                return BadRequest("Not role deleted");
            }

            return Ok("Role deleted");
        }
    }
}
