using Dominio.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Dominio.Entidades
{
    public class Despesa : EntityBase.EntityBase
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool Pago { get; set; }
        public CategoriaDespesa Categoria { get; set; }

        public Despesa()
        {
            
        }

        public Despesa(string descricao, decimal valor,DateTime datavencimento,DateTime?dataPagamento,bool pago,CategoriaDespesa categoria)
        {
            Descricao = descricao;
            Valor = valor;
            DataVencimento = datavencimento;
            DataPagamento = dataPagamento;
            Pago = pago;

            Categoria = categoria;
        }
    }
}
