using Microsoft.AspNetCore.Mvc;
using Db.Interfaces;
using Db.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IRepository<Db.Models.Task> _taskRepository;
        private readonly IRepository<Pessoa> _pessoaRepository;

        public TasksController(IRepository<Db.Models.Task> taskRepository, IRepository<Pessoa> pessoaRepository)
        {
            _taskRepository = taskRepository;
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Db.Models.Task task)
        {
            // Validar se o UserId está associado a um usuário existente
            var pessoa = await _pessoaRepository.GetByIdAsync(task.UserId);
            if (pessoa == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Adicionar a tarefa ao banco
            await _taskRepository.AddAsync(task);
            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }
    }
}
