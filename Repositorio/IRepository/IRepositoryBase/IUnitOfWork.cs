using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository.IRepositoryBase
{
    public interface IUnitOfWork
    {
        IAlunoRepository Aluno { get; }
        IProfessorRepository Professo { get; }
        ITurmaRepository Turma { get; }
        IMensalidadeRepository Mensalidade { get; }
        IChamadaRepository Chamada { get; }
        IChamadaItemRepository ChamadaItem { get; }
        IAlunoTurmaRepository AlunoTurma { get; }
        IDespesaRepository Despesa { get; }
        IRankingRepository Ranking { get; }

        IHistoricoDoAlunoRepository historicoDoAluno { get; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task<int> CompleteAsync();
        void Rollback();
    }
}
