using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    internal class Task
    {
        public int id { get; set; }
        public required string nome { get; set; }
        public required string categoria { get; set; }
        public int userId { get; set; }

    }
}
