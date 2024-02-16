using AutoMapper;
using reviewAppWebAPI.Dto;
using reviewAppWebAPI.Model;

namespace reviewAppWebAPI.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
