using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class AdicionarAtualizaProfessorModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public decimal Salario { get;  set; }
    }
}
