using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using Repositorio.IRepository.IRepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class RankingRepository : RepositoryBase<Ranking>, IRankingRepository
    {
        private readonly Contexto _contexto;

        public RankingRepository(Contexto contexto) : base(contexto) 
        {
            _contexto = contexto;
        }

        public async Task<Ranking> ObterPorAluno(Guid alunoId)
        {
           return  await _context.Rankings.AsNoTracking().FirstOrDefaultAsync(c => c.Alunoid == alunoId);
        }

        public Task<IEnumerable<Ranking>> ObterPorTurma(Guid TurmaId)
        {
            throw new NotImplementedException();
        }
    }
}
