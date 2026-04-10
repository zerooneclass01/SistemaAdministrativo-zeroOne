using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class PresencaDetalheModel
    {
        public DateTime Data { get; set; }
        public bool Presente { get; set; }
        public string? Justificativa { get; set; }
    }
}
