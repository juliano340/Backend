using Microsoft.AspNetCore.Mvc;
using Db.Interfaces;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IRepository<Db.Models.Task> _repository;

        public TasksController(IRepository<Db.Models.Task> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _repository.GetAllAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Db.Models.Task task)
        {
            await _repository.AddAsync(task);
            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }
    }

}