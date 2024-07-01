using Microsoft.AspNetCore.Identity;
using reviewAppWebAPI.Data;
using reviewAppWebAPI.Interfaces;
using reviewAppWebAPI.Model;
using System.Threading.Tasks;

namespace reviewAppWebAPI.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async User FindByEmailAsync(string email)
        {
            return await _context.FindByEmailAsync(email);
        }

        public async bool CreateAsync(User user)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async bool CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
