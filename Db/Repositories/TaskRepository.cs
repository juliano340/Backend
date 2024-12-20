using Db.Models;
using Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Db.Repositories
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Task>> GetByUserIdAsync(int userId)
        {
            return await _context.Tasks
                                 .Where(t => t.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetTasksByCategoryAsync(string category)
        {
            return await _context.Tasks
                                 .Where(t => t.Categoria == category)
                                 .ToListAsync();
        }
    }
}
