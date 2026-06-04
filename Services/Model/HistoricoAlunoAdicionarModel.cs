using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public record class HistoricoAlunoAdicionarModel
    {
        public Guid AlunoId { get; set; }
        public Guid ProfessorId { get; set; }

        public int StatusComportamento { get; set; }

        public int StatusDesempenho { get; set; }

        public string Descricao { get; set; }
    }
}
