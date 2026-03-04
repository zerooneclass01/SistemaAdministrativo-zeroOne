using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class MensalidadeModel
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public decimal Valor { get; set; }
        public decimal? ValorPago { get; set; }
        public decimal Desconto { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int Status { get; set; }
        public string StatusDescricao { get; set; }

        public MensalidadeModel Response(Mensalidade mensalidade)
        {
            if (mensalidade == null)
                return null;

            Id = mensalidade.Id;
            AlunoId = mensalidade.AlunoId;
            Valor = mensalidade.ValorOriginal;
            ValorPago = mensalidade.ValorPago;
            Desconto = mensalidade.Desconto;
            Vencimento = mensalidade.DataVencimento;
            DataPagamento = mensalidade.DataPagamento;
            Status = (int)mensalidade.PagamentoStatus;
            StatusDescricao = mensalidade.PagamentoStatus.ToString();

            return this;
        }
    }
}
