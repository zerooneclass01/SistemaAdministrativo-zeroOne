using Dominio.Entidades;
using Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public record class HistoricoAlunoModel
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public Guid ProfessorId { get; set; }
        public string NomeProfessor { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public StatusHistorico StatusComportamento { get; set; }
        public StatusHistorico StatusDesempenho { get; set; }
        public string Descricao { get; set; }

        public static HistoricoAlunoModel MapeamentoModel( HistoricoDoAluno model)
        {
            if (model == null)
                return null;

            return new HistoricoAlunoModel
            {
                Id = model.Id,
                AlunoId = model.AlunoId,
                ProfessorId = model.ProfessorId,
                NomeProfessor = model.Professor.Nome,
                DataRegistro = model.DataCadastro,
                DataAtualizacao = model.DataAtualizacao,
                StatusComportamento = model.StatusComportamento,
                StatusDesempenho = model.StatusDesempenho,
                Descricao = model.Descricao,
            };
        }
        public static IEnumerable<HistoricoAlunoModel> ParaListaModel( IEnumerable<HistoricoDoAluno> entidades)
        {
            if (entidades == null)
                return Enumerable.Empty<HistoricoAlunoModel>();

            return entidades.Select(entidade => MapeamentoModel(entidade));
        }

    }
}
