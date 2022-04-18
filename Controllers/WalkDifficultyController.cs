using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this._walkDifficultyRepository = walkDifficultyRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("/get/walkdifficulties")]
        public async Task<IActionResult> GetWalkDifficultiesAsync()
        {
            var result = await _walkDifficultyRepository.GetAllAsync();
            if (result == null)
            {
                return NotFound("No walk difficulties found");
            }

            var walkDifficulties = _mapper.Map<IEnumerable<WalkDifficultyDTO>>(result);

            return Ok(walkDifficulties);
        }

        [HttpGet]
        [Route("/get/walkdifficulty/{id:guid}")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
        {
            var exist = await this._walkDifficultyRepository.GetByIdAsync(id);
            if (exist == null)
            {
                return NotFound("No walk difficulty found");
            }

            var difficultyDTO = this._mapper.Map<WalkDifficultyDTO>(exist);

            return Ok(difficultyDTO);
        }

        [HttpPost]
        [Route("/add/walkdifficulty")]
        public async Task<IActionResult> AddWalkDifficultyAsync([FromBody] WalkDifficultyDTO walkDifficultyDTO)
        {
            var walkDifficulty = this._mapper.Map<WalkDifficulty>(walkDifficultyDTO);

            var exist = await this._walkDifficultyRepository.GetByCodeAsync(walkDifficulty.Code!); 

            if(exist)
            {
                return BadRequest("WalkDifficulty already exist");
            }

            var result = await this._walkDifficultyRepository.AddAsync(walkDifficulty);
            if(!result)
            {
                return BadRequest("WalkDifficulty cannot be added");
            }

            return Ok("WalkDifficulty added");
        }

        [HttpPut]
        [Route("/update/walkdifficulty/{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] UpdateWalkDifficultyDTO updateWalkDifficultyDTO)
        {
            var exist = await this._walkDifficultyRepository.GetByIdAsync(id);
            if(exist == null)
            {
                return NotFound("WalkDifficulty doesn't exist");
            }

            var updateWalkDifficulty = this._mapper.Map<WalkDifficulty>(exist);

            var result = await this._walkDifficultyRepository.UpdateAsync(updateWalkDifficulty);
            if(!result)
            {
                return BadRequest("WalkDifficulty cannot be updated");
            }

            return Ok("WalkDifficulty updated");
        }

        [HttpDelete]
        [Route("/delete/walkdifficulty/{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync([FromRoute] Guid id)
        {
            var exist = await this._walkDifficultyRepository.GetByIdAsync(id);
            if(exist == null)
            {
                return NotFound("WalkDifficulty not found");
            }

            var walkDifficultyToDelete = this._mapper.Map<WalkDifficulty>(exist);

            var result = await this._walkDifficultyRepository.DeleteAsync(walkDifficultyToDelete);
            if(!result)
            {
                return BadRequest("WalkDifficulty cannot be deleted");
            }

            return Ok("WalkDifficulty deleted");
        }
    }
}
