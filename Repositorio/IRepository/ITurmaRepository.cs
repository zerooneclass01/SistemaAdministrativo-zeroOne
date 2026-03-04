using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface ITurmaRepository : IRepositoryBase<Turma>
    {
        Task<Turma> ObterPorIdCompletoAsync(Guid id);
    }
}
