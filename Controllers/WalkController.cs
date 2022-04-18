using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this._walkRepository = walkRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("/get/walks")]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walks = await this._walkRepository.GetAllAsync();
            if (walks == null)
            {
                return NotFound("No walks found");
            }

            var walksDTO = this._mapper.Map<IEnumerable<WalkDTO>>(walks);
            
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("/get/walk/{id:guid}")]
        public async Task<IActionResult> GetWalkByIdAsync(Guid id)
        {
            var walk = await this._walkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound("No walk found");
            }
            var walkDTO = this._mapper.Map<WalkDTO>(walk);
            return Ok(walkDTO);
        }

        [HttpPost]
        [Route("/add/Walk")]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkDTO addWalkDTO)
        {
            var walk = this._mapper.Map<Walk>(addWalkDTO);
            var exist = await this._walkRepository.GetByNameAsync(walk);
            if (exist != null)
            {
                return BadRequest("Walk already exist");
            }

            var result = await this._walkRepository.AddAsync(walk);
            if (!result)
            {
                return BadRequest("Failed to add walk");
            }

            return Ok("Walk added successfully");
        }

        [HttpPut]
        [Route("/update/Walk/{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkDTO updateWalkDTO)
        {
            var exist = await this._walkRepository.GetByIdAsync(id);
            if (exist == null)
            {
                return NotFound("No walk found");
            }

            var walk = this._mapper.Map<Walk>(updateWalkDTO);

            var result = await this._walkRepository.UpdateAsync(id, walk);
            if(!result)
            {
                return BadRequest("Failed to update walk");
            }

            return Ok("Walk updated successfully");
        }

        [HttpDelete]
        [Route("/delete/Walk/{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
        {
            var exist = await this._walkRepository.GetByIdAsync(id);
            if (exist == null)
            {
                return NotFound("No walk found");
            }

            var result = await this._walkRepository.DeleteAsync(exist);
            if (!result)
            {
                return BadRequest("Failed to delete walk");
            }

            return Ok("Walk deleted successfully");
        }

    }
}
