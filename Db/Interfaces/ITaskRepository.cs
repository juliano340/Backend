using Db.Models;

namespace Db.Interfaces
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        Task<IEnumerable<Models.Task>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Models.Task>> GetTasksByCategoryAsync(string category);
    }
}
