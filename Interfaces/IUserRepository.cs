using reviewAppWebAPI.Model;

namespace reviewAppWebAPI.Interfaces
{
    public interface IUserRepository
    {
        User FindByEmailAsync(string email);
        bool CreateAsync(User user);
        bool CheckPasswordAsync(User user, string password);
    }
}
