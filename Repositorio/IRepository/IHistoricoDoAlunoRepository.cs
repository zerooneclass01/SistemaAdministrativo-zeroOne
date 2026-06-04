using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IHistoricoDoAlunoRepository : IRepositoryBase<HistoricoDoAluno>
    {
        Task<List<HistoricoDoAluno>> ListaHistoricoAluno(Guid aluno);
    }
}
