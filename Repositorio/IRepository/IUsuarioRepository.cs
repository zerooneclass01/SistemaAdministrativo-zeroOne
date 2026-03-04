using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.IRepository
{
    public interface IUsuarioRepository
    {
        // Métodos de Busca (Leitura)
        Task<Usuario?> ObterPorId(int id);
        Task<Usuario?> ObterPorUsername(string username);
        Task<Usuario?> ObterPorToken(string token);

        // Métodos de Comando (Escrita)
        Task Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Task Deletar(Usuario usuario);

        // Persistência
        Task<bool> SalvarAlteracoes();
    }
}
