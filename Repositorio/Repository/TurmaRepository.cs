using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class TurmaRepository : RepositoryBase<Turma>, ITurmaRepository
    {
        private readonly Contexto _contexto;

        public TurmaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Turma> ObterPorIdCompletoAsync(Guid id)
        {
            return await _context.Turmas
             .Include(t => t.Professor)
             .Include(t => t.Alunos)
             .AsNoTracking()
             .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
