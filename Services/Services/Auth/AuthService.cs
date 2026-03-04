using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.Auth
{
    public class AuthService
    {
        public string HashSenha(string senha) =>
        BCrypt.Net.BCrypt.HashPassword(senha);

        public bool VerificarSenha(string senha, string hash) =>
            BCrypt.Net.BCrypt.Verify(senha, hash);
    }
}
