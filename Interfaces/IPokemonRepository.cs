using reviewAppWebAPI.Model;

namespace reviewAppWebAPI.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
        bool CreatePoke(int ownerId, int categoryId, Pokemon pokemon);
        bool UpdatePoke(int ownerId, int categoryId, Pokemon pokemon);
        bool Save();
    }
}
