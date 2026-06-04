using Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class HistoricoDoAluno : EntityBase.EntityBase
    {

        public Guid AlunoId { get; private set; }


        public Guid ProfessorId { get; private set; }


        public DateTime? DataAtualizacao { get; private set; }

        public StatusHistorico StatusComportamento { get; private set; }


        public StatusHistorico StatusDesempenho { get; private set; }

        public string Descricao { get; private set; }

        public Aluno Aluno { get; set; }
        public Professor Professor { get; set; }

        public HistoricoDoAluno()
        {

        }

        public string Adicionar(Guid alunoId, Guid professorId, int statusComportamento, int statusDesempenho, string descricao)
        {

            if (alunoId == Guid.Empty || professorId == Guid.Empty)
            {
                return "Id do aluno ou do Professor não pode ser vazio.";
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                return "A descrição do histórico é obrigatória.";
            }

            AlunoId = alunoId;
            ProfessorId = professorId;
            StatusComportamento = (StatusHistorico) statusComportamento;
            StatusDesempenho = (StatusHistorico) statusDesempenho;
            Descricao = descricao;

            return null;
        }

        public string Atualizar(string descricao, int statustoComportamento, int statusDesempenho)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return "A descrição do històrico é obrigatório.";

            Descricao = descricao;
            StatusComportamento = (StatusHistorico)statustoComportamento;
            StatusDesempenho = (StatusHistorico)statusDesempenho;
            DataAtualizacao = DateTime.UtcNow;

            return null;
        }
    }
}
