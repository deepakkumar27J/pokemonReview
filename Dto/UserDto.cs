using System.ComponentModel.DataAnnotations;

namespace reviewAppWebAPI.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        // Optional: If you have roles or other properties
        public string Role { get; set; }
    }
}
