using Microsoft.AspNetCore.Identity;
using reviewAppWebAPI.Data;
using reviewAppWebAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reviewAppWebAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public Seed(DataContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dataContext = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedDataContext()
        {
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
                {
                    // Your existing data seeding code
                };
                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }

            await SeedUsers();
        }

        private async Task SeedUsers()
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (userManager.Users.Any())
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var normalUser = new ApplicationUser
            {
                UserName = "user",
                Email = "user@example.com",
                EmailConfirmed = true
            };

            result = await userManager.CreateAsync(normalUser, "UserPassword123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
    }
}
