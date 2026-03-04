using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IUsuarioServices
    {
        Task<string?> Login(LoginRequest request);
        Task<bool> Cadastrar(CriarUsuarioRequest request);
        Task<bool> EsqueciSenha(string email);
        Task<bool> ResetarSenha(ResetSenhaRequest request);
    }
}
