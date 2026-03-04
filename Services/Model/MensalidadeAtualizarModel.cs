using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Services.Model
{
    public class MensalidadeAtualizarAdicionarModel
    {
        public Guid IdAluno { get; set; }
        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public MensalidadeAtualizarAdicionarModel Response(Mensalidade mensalidade)
        {
            if (mensalidade == null)
                return null;

            IdAluno = mensalidade.AlunoId;
            Valor = mensalidade.ValorOriginal;
            DataVencimento = mensalidade.DataVencimento;

            return this;
        }
    }
}
