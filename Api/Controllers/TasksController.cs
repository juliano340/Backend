using Db.Interfaces;
using Db.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IRepository<Db.Models.Task> _genericTaskRepository;
        private readonly IRepository<Pessoa> _pessoaRepository;
        private readonly ITaskRepository _taskRepository;

        public TasksController(IRepository<Db.Models.Task> genericTaskRepository, IRepository<Pessoa> pessoaRepository, ITaskRepository taskRepository)
        {
            _genericTaskRepository = genericTaskRepository;
            _pessoaRepository = pessoaRepository;
            _taskRepository = taskRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _genericTaskRepository.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _genericTaskRepository.GetByIdAsync(id);

            if (task == null)
                return NotFound("Tarefa não encontrada.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Db.Models.Task task)
        {            
            var pessoa = await _pessoaRepository.GetByIdAsync(task.UserId);
            if (pessoa == null)            
                return NotFound("Usuário não encontrado.");
                                    
            await _genericTaskRepository.AddAsync(task);
            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Db.Models.Task updatedTask)
        {
            var existingTask = await _genericTaskRepository.GetByIdAsync(id);
            if (existingTask == null)
                return NotFound("Tarefa não encontrada.");
                                    
            existingTask.Nome = updatedTask.Nome ?? existingTask.Nome;
            existingTask.Categoria = updatedTask.Categoria ?? existingTask.Categoria;
                        
            await _genericTaskRepository.UpdateAsync(existingTask);

            return Ok(existingTask);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var userTasks = await _taskRepository.GetByUserIdAsync(userId);

            if (!userTasks.Any())
            {
                return NotFound($"Nenhuma tarefa encontrada para o usuário com ID {userId}.");
            }

            return Ok(userTasks);
        }

    }
}
