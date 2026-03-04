using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class AlunoCriarModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public decimal ValorMensalidade { get; set; }
        public int DiaVencimento { get; set; }

        public Guid? TurmaId { get; set; }
    }
}
