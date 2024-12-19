using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<Models.Task> Tasks { get; set; } = null!;


    }
}
