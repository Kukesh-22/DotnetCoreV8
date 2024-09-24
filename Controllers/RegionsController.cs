using AutoMapper;
using Dotnet_v8.Context;
using Dotnet_v8.Models.Domain;
using Dotnet_v8.Models.DTOs;
using Dotnet_v8.Repository;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController(V8DBContext context, IRegionRepository repository,IMapper mapper) : ControllerBase
    {
        private readonly V8DBContext _context = context;
        private readonly IRegionRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        //private readonly ILogger<RegionsController> logger;

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await repository.GetAllAsync();

            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await _repository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }
            return Ok(regionDomain);
        }

        [HttpPost]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var region = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            region = await _repository.CreateAsync(region);

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDetail = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };

            await _repository.UpdateAsync(id, regionDetail);

            var regiondto = new RegionDto
            {
                Id = regionDetail.Id,
                Code = regionDetail.Code,
                Name = regionDetail.Name,
                RegionImageUrl = regionDetail.RegionImageUrl,
            };

            return Ok(regiondto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _repository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(regionDomainModel);
        }
    }
}