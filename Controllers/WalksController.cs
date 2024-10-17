using AutoMapper;
using Dotnet_v8.Models.Domain;
using Dotnet_v8.Models.DTOs;
using Dotnet_v8.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_v8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController(IWalksRepository walksRepository, IMapper mapper) : ControllerBase
    {
        private readonly IWalksRepository _walksRepository = walksRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksRecord = await _walksRepository.GetAllWalks(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            return Ok(_mapper.Map<List<WalkDto>>(walksRecord));
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walksRecord = await _walksRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<WalkDto>(walksRecord));
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto walkRequest)
        {

            var walk = _mapper.Map<Walk>(walkRequest);
            await _walksRepository.CreateAsync(walk);
            return Ok(_mapper.Map<WalkDto>(walk));
        }
    }
}
