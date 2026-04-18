using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IUsuarioServices
    {
        Task<LoginResponse?> Login(LoginRequest request);

        Task<List<UsuarioModel>> ObterTodos();
        Task<bool> Cadastrar(CriarUsuarioRequest request);
        Task<bool> EsqueciSenha(string usuario,string telefone);
        Task<bool> ResetarSenha(ResetSenhaRequest request);
    }
}
