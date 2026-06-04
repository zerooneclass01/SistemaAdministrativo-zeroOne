using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class HistoricoDoAlunoRepository : RepositoryBase<HistoricoDoAluno>,IHistoricoDoAlunoRepository
    {
        private readonly Contexto _contexto;

        public HistoricoDoAlunoRepository(Contexto contexto) : base(contexto) 
        {
            _contexto = contexto;
        }

        public async Task<List<HistoricoDoAluno>> ListaHistoricoAluno(Guid aluno)
        {
            return await _contexto.HistoricoDoAlunos.Where(h => h.AlunoId == aluno).AsNoTracking().ToListAsync();
        }
    }
}
