using AutoMapper;
using Dotnet_v8.Models.Domain;
using Dotnet_v8.Models.DTOs;
using Dotnet_v8.Repository;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAll()
        {
            var walksRecord = await _walksRepository.GetAllWalks();
            return Ok(_mapper.Map<List<WalkDto>>(walksRecord));
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walksRecord = await _walksRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<WalkDto>(walksRecord));
        }
        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto walkRequest)
        {
            var walk = _mapper.Map<Walk>(walkRequest);
            await _walksRepository.CreateAsync(walk);
            return Ok(_mapper.Map<WalkDto>(walk));
        }
    }
}
