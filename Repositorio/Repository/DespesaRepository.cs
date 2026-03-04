using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class DespesaRepository : RepositoryBase<Despesa>, IDespesaRepository
    {
        private readonly Contexto _contexto;

        public DespesaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Despesa>> ObterPorPeriodo(int mes, int ano)
        {
            return await _context.Despesas
         .AsNoTracking() 
         .Where(x => x.DataVencimento.Month == mes && x.DataVencimento.Year == ano)
         .ToListAsync();
        }
    }
}
