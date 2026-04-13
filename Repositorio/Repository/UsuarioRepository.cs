using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;

        public UsuarioRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
        }

        public async Task Deletar(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterPorId(Guid id)
        {
            return await _contexto.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario?> ObterPorToken(string token)
        {
            return await _contexto.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.PasswordResetToken== token && u.Ativo);
        }

        public async Task<Usuario?> ObterPorUsername(string username)
        {
            return await _contexto.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

    }
}
