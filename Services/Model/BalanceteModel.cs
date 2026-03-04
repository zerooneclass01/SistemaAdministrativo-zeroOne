using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class BalanceteModel
    {
        // Identificação do Período
        public string Periodo { get; set; } 
        public int Mes { get; set; }
        public int Ano { get; set; }

        // --- RECEITAS (O que entrou) ---
        public decimal TotalMensalidadesRecebidas { get; set; }
        public int QuantidadePagamentosRealizados { get; set; }

        // --- DESPESAS (O que saiu) ---
        public decimal TotalSalariosProfessores { get; set; }
        public decimal TotalGastosCurso { get; set; } // Luz, aluguel, internet, materiais
        public decimal TotalGeralDespesas => TotalSalariosProfessores + TotalGastosCurso;

        // --- RESULTADO FINAL ---
        public decimal SaldoLiquido { get; set; } // Receitas - Despesas
        public string StatusFinanceiro => SaldoLiquido >= 0 ? "Lucro" : "Prejuízo";

        // --- INDICADORES DE ATENÇÃO (Inadimplência) ---
        public decimal ValorPendenteReceber { get; set; } // Mensalidades que venceram e não foram pagas
        public int QuantidadeAlunosInadimplentes { get; set; }

        public BalanceteModel Response(
            int mes,
            int ano,
            IEnumerable<Mensalidade> mensalidades,
            IEnumerable<Despesa> despesas,
            IEnumerable<Professor> professores)
        {
            Mes = mes;
            Ano = ano;
            Periodo = $"{mes:D2}/{ano}";

            // --- CÁLCULO DE RECEITAS ---
            var mensalidadesPagasNoMes = mensalidades
                .Where(m => m.PagamentoStatus == 0 && // Status Pago
                            m.DataPagamento.HasValue &&
                            m.DataPagamento.Value.Month == mes &&
                            m.DataPagamento.Value.Year == ano)
                .ToList();

            TotalMensalidadesRecebidas = mensalidadesPagasNoMes.Sum(m => m.ValorPago ?? 0m);
            QuantidadePagamentosRealizados = mensalidadesPagasNoMes.Count;

            // --- CÁLCULO DE DESPESAS ---
            TotalSalariosProfessores = professores.Sum(p => p.Salario);

            TotalGastosCurso = despesas
                .Where(d => d.DataVencimento.Month == mes && d.DataVencimento.Year == ano)
                .Sum(d => d.Valor);

            // --- RESULTADO ---
            SaldoLiquido = TotalMensalidadesRecebidas - TotalGeralDespesas;

            // --- INADIMPLÊNCIA (Atenção financeira) ---
            var pendentes = mensalidades
                .Where(m => !m.ValorPago.HasValue && m.DataVencimento.Month == mes && m.DataVencimento.Year == ano)
                .ToList();

            ValorPendenteReceber = pendentes.Sum(m => m.ValorOriginal);
            QuantidadeAlunosInadimplentes = pendentes.Count;

            return this;
        }
    }
}
