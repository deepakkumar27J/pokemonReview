using reviewAppWebAPI.Model;

namespace reviewAppWebAPI.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int id);
        ICollection<Owner> GetOwnerOfAPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int id);
        bool CreateOwner(Owner owner);
        bool Save();
    }
}
