using Dominio.Entidades.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository.IRepositoryBase
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task Adicionar(TEntity obj);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
    }
}
