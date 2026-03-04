using Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class AdicionarAtualizarTurmaModel
    {
        public string Nome { get;  set; }
        public string Horario { get;  set; }
        public Guid? ProfessorId { get;  set; }

        public int DiasDaSemana { get; set; }

        public DiaDaSemana ObterDiasEnum() => (DiaDaSemana)this.DiasDaSemana;
    }
}
