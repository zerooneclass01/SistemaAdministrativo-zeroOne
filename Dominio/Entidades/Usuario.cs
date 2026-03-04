using Dominio.Entidades.EntityBase;
using Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Usuario : EntityBase.EntityBase
    {
        public string Username { get; private set; } 
        public string SenhaHash { get;private set; } 
        public UserRole Role { get;private set; } 

        // Propriedades para o "Esqueci minha senha"
        public string? PasswordResetToken { get;private set; }
        public DateTime? ResetTokenExpires { get;private set; }

        public bool Ativo { get;private set; } = true;

        public Usuario()
        {
            
        }
        public Usuario(string userName, string senhaHash, int role)
        {
            InserirDados(userName, senhaHash, role);
        }

        public void InserirDados(string userName, string senhaHash, int role)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("Por favor digite o seu e - mail.");

            if (string.IsNullOrEmpty(senhaHash))
                throw new ArgumentException("Por favor digite uma senha.");

            this.Username = userName;
            this.SenhaHash = senhaHash;
            this.Role = (UserRole)role;

        }

        public void ConfirmaSenhar(string senhar, string confirmaSenhra)
        {
            if (confirmaSenhra != senhar)
                throw new ArgumentException("A senhas não concidem.");

            this.SenhaHash = senhar;
        }
        public void GerarTokenRecuperacao()
        {
            this.PasswordResetToken = Guid.NewGuid().ToString();
            this.ResetTokenExpires = DateTime.UtcNow.AddHours(2);
        }


        public void ResetarSenha(string novoHash, string tokenInformado)
        {
            if (string.IsNullOrEmpty(this.PasswordResetToken) || this.PasswordResetToken != tokenInformado)
                throw new ArgumentException("Token de recuperação inválido.");

            if (this.ResetTokenExpires < DateTime.UtcNow)
                throw new ArgumentException("O token de recuperação expirou.");

            this.SenhaHash = novoHash;

            this.PasswordResetToken = null;
            this.ResetTokenExpires = null;
        }

        public bool Desativar ()=> this.Ativo = false;
        public bool Ativar () => this.Ativo = true;
    }
}
