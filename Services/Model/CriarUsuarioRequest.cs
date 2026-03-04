using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public record CriarUsuarioRequest
    {
        public string Username { get; set; }
        public string Senha { get; set; }

        public int  Role { get; set; }
    }
}
