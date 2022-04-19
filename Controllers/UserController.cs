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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("/list/users")]
        [Authorize]
        public async Task<IActionResult> GetUsersAync()
        {
            var users = await this._userRepository.GetAllUsersAsync();
            var usersDTO = this._mapper.Map<List<UserDTO>>(users);
            return Ok(usersDTO);
        }

        [HttpGet]
        [Route("/show/user/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetUserAync(Guid id)
        {
            var exist = await this._userRepository.GetUserAsync(id);
            if (exist == null)
            {
                return NotFound("User doesn't exist");
            }

            var userDTO = this._mapper.Map<UserDTO>(exist);
            return Ok(userDTO);
        }

        [HttpPost]
        [Route("/create/user")]
        public async Task<IActionResult> AddUserAsync(AddUserDTO addUserDTO)
        {
            var user = this._mapper.Map<User>(addUserDTO);
            var exist = await this._userRepository.GetUserByNameAsync(user.Username!);
            if (exist != null)
            {
                return BadRequest("User already exist");
            }

            var result = await this._userRepository.AddUserAsync(user);
            if (!result)
            {
                return BadRequest("User can't be added");
            }

            return Ok("User added");
        }

        [HttpPut]
        [Route("/update/user/{id:guid}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UpdateUserDTO updateUserDTO)
        {
            var exist = await this._userRepository.GetUserAsync(id);
            if (exist == null)
            {
                return NotFound("User doesn't exist");
            }

            var user = this._mapper.Map<User>(updateUserDTO);
            var result = await this._userRepository.UpdateUserAsync(id, user);
            if (!result)
            {
                return BadRequest("User can't be updated");
            }

            return Ok("User updated");
        }

        [HttpDelete]
        [Route("/delete/user/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAync(Guid id)
        {
            var exist = await this._userRepository.GetUserAsync(id);
            if (exist == null)
            {
                return NotFound("User doesn't exist");
            }

            var result = await this._userRepository.DeleteUserAsync(exist);
            if (!result)
            {
                return BadRequest("User can't be deleted");
            }

            return Ok("User deleted");
        }
    }
}
