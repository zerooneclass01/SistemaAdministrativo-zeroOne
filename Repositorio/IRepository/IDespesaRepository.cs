using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IDespesaRepository : IRepositoryBase<Despesa>
    {
        Task<IEnumerable<Despesa>> ObterPorPeriodo(int mes, int ano);
    }
}
