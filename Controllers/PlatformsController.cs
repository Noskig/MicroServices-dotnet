using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatfromRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatfromRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting platforms...");

            var platformsItems = _repo.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformsItems));
        }
        [HttpGet("{íd}", Name ="GetplatformById")]
        public ActionResult<PlatformReadDto> GetplatformById(int id)
        {
            var platformItem = _repo.GetPlatforById(id);
            if(platformItem != null) { 
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            return NotFound();

        } 
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repo.CreatePlatform(platformModel);
            _repo.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            return CreatedAtRoute(nameof(GetplatformById), new {Id = platformReadDto.Id}, platformReadDto);

        }
    }
}
