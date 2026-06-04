using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public record HistoricoAtualizarModel
    {

        public int StatusComportamento { get; set; }

        public int StatusDesempenho { get; set; }

        public string Descricao { get; set; }
    }
}
