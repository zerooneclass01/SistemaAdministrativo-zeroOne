using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IMensalidadeRepository :IRepositoryBase<Mensalidade>
    {
        Task<List<Mensalidade>> ObterPeloIdAluno(Guid alunoId);

        Task<List<Mensalidade>> ListaVencidas();
    }
}
