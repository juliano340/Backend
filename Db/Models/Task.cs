namespace Db.Models
{
    public class Task
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Categoria { get; set; }
        public int UserId { get; set; } 
    }
}
