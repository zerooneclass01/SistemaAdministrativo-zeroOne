using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class AlunoRelatorioModel
    {
        public string Nome { get; set; }
        public int TotalPresencas { get; set; }
        public int TotalFaltas { get; set; }
        public double Frequencia { get; set; }

      
        public List<PresencaDetalheModel> PresencasDetalhes { get; set; }


        public AlunoRelatorioModel(string nome, int presencas, int totalAulas, List<PresencaDetalheModel> detalhes)
        {
            Nome = nome;
            TotalPresencas = presencas;
            TotalFaltas = totalAulas - presencas;
            Frequencia = totalAulas > 0 ? (double)presencas / totalAulas * 100 : 0;

            PresencasDetalhes = detalhes;
        }
    }
}