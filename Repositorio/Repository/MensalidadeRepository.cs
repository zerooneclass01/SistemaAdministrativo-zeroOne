using Dominio.Entidades;
using Dominio.Entidades.Enum;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Repositorio.Repository
{
    public class MensalidadeRepository : RepositoryBase<Mensalidade>, IMensalidadeRepository
    {
        private readonly Contexto _contexto;

        public MensalidadeRepository(Contexto contexto):base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Mensalidade>> ListaVencidas()
        {
            var hoje = DateTime.Now;
            return await _context.Mensalidades
             .Where(m => m.DataVencimento < hoje &&
                         m.PagamentoStatus == PagamentoStatus.Pendente).AsNoTracking()
             .ToListAsync();
        }

        public async Task<List<Mensalidade>> ObterPeloIdAluno(Guid alunoId)
        {
            return await _context.Mensalidades.Where(m => m.AlunoId == alunoId )
                .OrderByDescending(m => m.DataVencimento).AsNoTracking()
                .ToListAsync();
        }
    }
}
