using Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Services.Model
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Username { get;  set; }
        public string Role { get;  set; }
    }
}
