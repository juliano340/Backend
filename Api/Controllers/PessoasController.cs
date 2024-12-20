using Db.Interfaces;
using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.DTOs.Pessoa.cs;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IRepository<Pessoa> _repository;

        public PessoasController(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pessoas = await _repository.GetAllAsync();

            var pessoasDto = pessoas.Select(pessoa => new PessoaDto
            {
                Id = pessoa.Id,
                Name = pessoa.Name,
                Email = pessoa.Email,
                Role = pessoa.Role.ToString()
            }).ToList();

            return Ok(pessoasDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pessoa = await _repository.GetByIdAsync(id);

            if (pessoa == null) return NotFound();

            var pessoaDto = new PessoaDto
            {
                Id = pessoa.Id,
                Name = pessoa.Name,
                Email = pessoa.Email,
                Role = pessoa.Role.ToString()
            };

            return Ok(pessoaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(pessoa);

            var pessoaDTO = new PessoaDto
            {
                Id = pessoa.Id,
                Name = pessoa.Name,
                Email = pessoa.Email,
                Role = pessoa.Role.ToString()
            };

            return StatusCode(201, pessoaDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PessoaUpdateDTO updateDto)
        {
            if (!ModelState.IsValid)          
                return BadRequest(ModelState);
                                    
            var pessoa = await _repository.GetByIdAsync(id);
            if (pessoa == null) return 
                    NotFound("Usuário não encontrado.");            
                        
            if (updateDto.Nome != null)
                pessoa.Name = updateDto.Nome;

            if (updateDto.Email != null)
                pessoa.Email = updateDto.Email;

            if (updateDto.Role != null && Enum.TryParse(updateDto.Role, out Pessoa.UserRole role))
                pessoa.Role = role;
            
            await _repository.UpdateAsync(pessoa);
                        
            return Ok(new PessoaDto
            {
                Id = pessoa.Id,
                Name = pessoa.Name,
                Email = pessoa.Email,
                Role = pessoa.Role.ToString()
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        
        {
            var pessoa = await _repository.GetByIdAsync(id);
            if (pessoa == null) 
                return NotFound("Usuário não encontrado.");
            
            await _repository.DeleteAsync(id);
            return NoContent();

        }


    }
}
