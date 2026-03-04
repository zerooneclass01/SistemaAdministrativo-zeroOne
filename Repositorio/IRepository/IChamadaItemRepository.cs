using Dominio;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IChamadaItemRepository : IRepositoryBase<ChamadaItem>
    {
        Task<IEnumerable<ChamadaItem>> ObterFaltasPorAluno(Guid alunoId);

        Task<IEnumerable<ChamadaItem>> ObterPresencasPorAluno(Guid alunoId);
        Task<List<ChamadaItem>> ObterPorChamadaId(Guid chamadaId);

    }
}
