using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Model
{
    public class RelatorioTurmaModel
    {
        public string TurmaNome { get; set; }
        public int TotalAulasNoPeriodo { get; set; }
        public List<AlunoRelatorioModel> Alunos { get; set; }

        public RelatorioTurmaModel(string nomeTurma, IEnumerable<Chamada> chamadas)
        {
            var chamadasLista = chamadas.ToList();

            TurmaNome = nomeTurma;
            TotalAulasNoPeriodo = chamadasLista.Count;

            Alunos = chamadasLista
                .SelectMany(c => c.AlunosPresenca.Select(ap => new {
                    ap.AlunoId,
                    ap.Aluno.Nome,
                    ap.Presente,
                    ap.Observacao,
                    DataAula = c.DataAula // Certifique-se que o nome na entidade Chamada é DataAula
                }))
                .GroupBy(ap => new { ap.AlunoId, ap.Nome })
                .Select(g => new AlunoRelatorioModel(
                    g.Key.Nome,
                    g.Count(x => x.Presente),
                    TotalAulasNoPeriodo,
                    g.Select(d => new PresencaDetalheModel
                    {
                        Data = d.DataAula,
                        Presente = d.Presente,
                        Justificativa = d.Observacao ?? "Sem justificativa"
                    }).OrderBy(d => d.Data).ToList()
                ))
                .OrderBy(a => a.Nome)
                .ToList();
        }
    }
}