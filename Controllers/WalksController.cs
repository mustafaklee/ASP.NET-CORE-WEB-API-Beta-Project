using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApiProject.Models.DTO;
using MyFirstApiProject.Repositories;
using MyFirstApiProjects.Models.Domain;
namespace MyFirstApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        //dikkat!! sqlwalkrepositories değil IWalkRepository
        private readonly IWalkRepository walkRepositories;
        public WalksController(IMapper mapper, IWalkRepository walkRepositories)
        {
            this.mapper = mapper;
            this.walkRepositories = walkRepositories;
        }
        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] WalkRequestDto walkRequestDto)
        {
            var walkDomain = mapper.Map<Walk>(walkRequestDto);

            walkDomain = await walkRepositories.CreateWalkAsync(walkDomain);

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            //return CreatedAtAction(nameof(GetWalkById),new { id = walkDto.Id }, walkDto);
            return Ok(walkDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await walkRepositories.GetAllWalksAsync();
            var walkDtos = mapper.Map<List<WalkDto>>(walks);
            return Ok(walkDtos);
        }


    }
}
