using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using reviewAppWebAPI.Data;
using reviewAppWebAPI.Dto;
using reviewAppWebAPI.Interfaces;
using reviewAppWebAPI.Model;
using reviewAppWebAPI.Repository;

namespace reviewAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController: Controller
    {
        private readonly IOwnerRepository _onwerRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository onwerRepository, IMapper mapper)
        {
            _onwerRepository = onwerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_onwerRepository.GetOwners());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);

        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_onwerRepository.OwnerExists(ownerId))
                return NotFound();
            var owner = _mapper.Map<OwnerDto>(_onwerRepository.GetOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owner);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
            if (!_onwerRepository.OwnerExists(ownerId))
                return NotFound();
            var owner = _mapper.Map<List<PokemonDto>>(_onwerRepository.GetPokemonByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owner);
        }
    }
}
