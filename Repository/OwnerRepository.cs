using AutoMapper;
using reviewAppWebAPI.Data;
using reviewAppWebAPI.Interfaces;
using reviewAppWebAPI.Model;

namespace reviewAppWebAPI.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OwnerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o=>o.Id==ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p=>p.PokemonId==pokeId).Select(o=>o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p=> p.Owner.Id==ownerId).Select(p=>p.Pokemon).ToList();
        }

        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(o=>o.Id==id);
        }
    }
}
