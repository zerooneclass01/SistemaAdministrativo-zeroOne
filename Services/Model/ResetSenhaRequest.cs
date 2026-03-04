using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public record ResetSenhaRequest
    {
        public string Token { get; set; }
        public string Senha{ get; set; }
    }
}
