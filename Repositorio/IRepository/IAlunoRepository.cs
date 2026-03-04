using Dominio.Entidades;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        Task<int> ObterProximoSequencial();

        Task RemoverObjeto(Aluno aluno);

        Task<IEnumerable<Aluno>> ObterTodosComInformacoes();

        Task<Aluno> ObterTodasInformaçoaDeUmAluno(Guid id);
    }
}
