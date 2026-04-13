using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IRankingRepository :IRepositoryBase<Ranking>
    {

        Task<IEnumerable<Ranking>> ObterPorTurma(Guid TurmaId);
        Task<Ranking> ObterPorAluno(Guid alunoId);

    }
}
