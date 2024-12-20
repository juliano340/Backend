using System.ComponentModel.DataAnnotations;

namespace Db.Models
{
    public class Pessoa
    {
        public enum UserRole
        {
            None,
            Admin,
            User
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; }
    }
}
