using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this._userRepository = userRepository;
            this._tokenHandler = tokenHandler;
        }
        
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            //Validate the incoming request
            //Check if user is aunthenticated
            //Check username and password
            var isAuth = await this._userRepository.AuthenticationAsync(loginRequestDTO.Username!, loginRequestDTO.Password!);

            if (isAuth != null)
            {
                //Generate Token
                var token = this._tokenHandler.CreateTokenAsync(isAuth);
                return Ok(token.Result);
            }

            return BadRequest("Username or password is incorrect");

        }
    }
}
