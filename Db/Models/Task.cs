namespace Db.Models
{
    public class Task
    {
        public int id { get; set; }
        public required string nome { get; set; }
        public required string categoria { get; set; }
        public int userId { get; set; }
        public required Pessoa pessoa { get; set; }
    }
}
