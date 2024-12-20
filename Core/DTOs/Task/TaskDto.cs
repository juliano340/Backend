using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Task
{
    public class TaskDto
    {
        public int Id {  get; set; }
        public required string Nome { get; set; }
        public required string Categoria { get; set; }
        public int userId { get; set; }

    }
}
