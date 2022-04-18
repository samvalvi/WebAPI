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
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }
        
        [HttpGet]
        [Route("/get/regions")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var result = await this._regionRepository.GetAllAsync();
            if (result == null)
            {
                return NotFound("No regions found");
            }

            //Destination -> Source
            var regionsDTO = this._mapper.Map<IEnumerable<RegionDTO>>(result);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("/get/region/{id:guid}")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            var result = await this._regionRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("No region found");
            }

            var regionDTO = this._mapper.Map<RegionDTO>(result);
            return Ok(regionDTO);
        }

        [HttpPost]
        [Route("/add/region")]
        [Authorize]
        public async Task<IActionResult> AddRegionAsync([FromBody] AddRegionDTO regionDTO)
        {
            var region = this._mapper.Map<Region>(regionDTO);
            var exist = await this._regionRepository.GetByNameAsync(region);
            if (exist != null)
            {
                return BadRequest("Region already exists");
            }

            var result = await this._regionRepository.InsertAsync(region);
            if(!result)
            {
                return BadRequest("Failed to add region");
            }

            return Ok("Region added successfully");
        }

        [HttpPut]
        [Route("/update/region/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
            var exist = await this._regionRepository.GetByIdAsync(id);
            if (exist == null)
            {
                return NotFound("No region found");
            }
            
            var region = this._mapper.Map<Region>(updateRegionDTO);
            var result = await this._regionRepository.UpdateAsync(id, region);
            if (!result)
            {
                return BadRequest("Failed to update region");
            }

            return Ok("Region updated successfully");
        }

        [HttpDelete]
        [Route("/delete/region/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var exist = await this._regionRepository.GetByIdAsync(id);
            if (exist == null)
            {
                return NotFound("No region found");
            }

            var result = await this._regionRepository.DeleteAsync(exist);
            if (!result)
            {
                return BadRequest("Failed to delete region");
            }

            return Ok("Region deleted successfully");
        }

    }
}
