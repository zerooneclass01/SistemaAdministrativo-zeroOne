using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class AlunoAtualizarModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
