using Dominio.Entidades.EntityBase;
using Repositorio.IRepository.IRepositoryBase;
using Microsoft.EntityFrameworkCore; // Adicione esta biblioteca
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repositorio.Data;
using System.Collections.Frozen;

namespace Repositorio.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly Contexto _context; 
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(Contexto context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task Adicionar(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public async Task AdicionarVarios(List<TEntity> objs)
        {
            await _dbSet.AddRangeAsync(objs);
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public void Atualizar(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public void Remover(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}