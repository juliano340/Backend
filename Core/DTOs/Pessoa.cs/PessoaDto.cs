﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Pessoa.cs
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string Name { get; set; }



    }
}
