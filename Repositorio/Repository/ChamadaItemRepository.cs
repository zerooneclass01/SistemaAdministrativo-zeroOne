using Dominio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class ChamadaItemRepository : RepositoryBase<ChamadaItem>, IChamadaItemRepository
    {
        private readonly Contexto _contexto;

        public ChamadaItemRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<ChamadaItem>> ObterFaltasPorAluno(Guid alunoId)
        {
            return await _context.Set<ChamadaItem>()
                  .Include(x => x.Aluno)
                  .Where(x => x.AlunoId == alunoId && !x.Presente)
                  .ToListAsync();
        }

        public async Task<List<ChamadaItem>> ObterPorChamadaId(Guid chamadaId)
        {
            return await _context.chamadaItems
            .Where(x => x.ChamadaId == chamadaId)
            .ToListAsync();
        }

        public async Task<IEnumerable<ChamadaItem>> ObterPresencasPorAluno(Guid alunoId)
        {
            return await _context.Set<ChamadaItem>()
             .Include(x => x.Chamada) 
            .ThenInclude(c => c.Turma) 
            .Where(x => x.AlunoId == alunoId)
            .OrderByDescending(x => x.Chamada.DataAula)
            .ToListAsync();
        }
    }
}
