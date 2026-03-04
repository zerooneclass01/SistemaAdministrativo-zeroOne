using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IChamadaRepositoy : IRepositoryBase<Chamada>
    {
        Task<Chamada> ObterChamadaCompleta(Guid turmaId, DateTime data);
        Task<IEnumerable<Chamada>> ObterHistoricoPorTurma(Guid turmaId);
    }
}
