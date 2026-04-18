using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class AtualziarSenhaUsuario
    {
        public Guid Id { get; set; }

        public string Senha { get; set; }

        public string ConfirmaSenha { get; set; }
    }
}
