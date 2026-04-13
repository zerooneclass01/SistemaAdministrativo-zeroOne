using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class ChamadaRepository : RepositoryBase<Chamada>, IChamadaRepositoy
    {
        private readonly Contexto _contexto;

        public ChamadaRepository(Contexto context) : base(context)
        {
            _contexto = context;
        }

        public async Task<Chamada> ObterChamadaCompleta(Guid turmaId, DateTime data)
        {
            return await _context.Chamadas
                 .Include(c => c.AlunosPresenca)
                     .ThenInclude(cp => cp.Aluno)
                     .AsNoTracking()
                 .FirstOrDefaultAsync(c => c.TurmaId == turmaId && c.DataAula.Date == data.Date);
        }

        public async Task<IEnumerable<Chamada>> ObterHistoricoPorTurma(Guid turmaId)
        {
            return await _context.Chamadas
                .Include(c => c.Turma) // Traz os dados da Turma (Nome, etc)
                .Include(c => c.AlunosPresenca) // Traz a lista de itens da chamada
                    .ThenInclude(ci => ci.Aluno) // Dentro de cada item, traz os dados do Aluno (Nome, etc)
                .Where(c => c.TurmaId == turmaId)
                .OrderByDescending(c => c.DataAula).
                AsNoTracking()
                .ToListAsync();
        }
    }
}
