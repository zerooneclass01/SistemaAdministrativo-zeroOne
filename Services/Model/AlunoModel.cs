using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class AlunoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public decimal ValorMensalidade { get; set; }
        public int DiaVencimento { get; set; }
        public Guid TurmaId { get; set; }
        public TurmaModel Turma{ get; set; }
        public string NomeTurma { get; set; }

        public string NomeProfessor { get; set; }
        public List<MensalidadeModel> Mensalidades { get; set; }

        public AlunoModel() { }

        public AlunoModel Response(Aluno aluno)
        {
            this.Id = aluno.Id;
            this.Nome = aluno.Nome;
            this.Matricula = aluno.Matricula;
            this.Email = aluno.Email;
            this.Telefone = aluno.Telefone;
            this.Ativo = aluno.Ativo;
            this.ValorMensalidade = aluno.ValorMensalidadeContratual;
            this.DiaVencimento = aluno.DiaVencimento;

            if (aluno.Turma != null)
            {
                this.NomeTurma = aluno.Turma.Nome;
                this.NomeProfessor = aluno.Turma.Professor?.Nome ?? "Não atribuído";

                this.Turma = new TurmaModel
                {
                    Nome = aluno.Turma.Nome,
                    Professor = new ProfessorModel { Nome = this.NomeProfessor }
                };
            }
            else
            {
                this.NomeTurma = "Sem Turma";
                this.NomeProfessor = "N/A";
            }

            this.Mensalidades = aluno.Mensalidades.Select(m => new MensalidadeModel
            {
                Id = m.Id,
                Vencimento = m.DataVencimento,
                Valor = m.ValorOriginal,
                Status = (int)m.PagamentoStatus
            }).OrderBy(m => m.Vencimento).ToList(); 

            return this;
        }
    }
}
