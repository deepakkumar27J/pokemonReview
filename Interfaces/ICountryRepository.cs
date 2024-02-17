using reviewAppWebAPI.Model;

namespace reviewAppWebAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool CountryyExists(int id);
        bool CreateCountry(Country country);
        bool Save();
    }
}
