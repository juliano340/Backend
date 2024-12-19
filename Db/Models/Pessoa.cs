
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
        public int id { get; set; }
        public required string name { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public UserRole Role { get; set; }
        public required ICollection<Task> Tasks { get; set; }
    }
}
