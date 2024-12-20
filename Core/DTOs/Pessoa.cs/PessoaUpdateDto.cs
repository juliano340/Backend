using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Pessoa.cs
{
    public class PessoaUpdateDTO
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
