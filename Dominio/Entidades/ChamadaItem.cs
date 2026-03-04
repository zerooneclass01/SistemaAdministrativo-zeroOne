using Dominio.Entidades;
using Dominio.Entidades.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio
{
    public class ChamadaItem : EntityBase
    {

        [ForeignKey("ChamadaId")]
        public Guid ChamadaId { get; private set; }
        public virtual Chamada Chamada { get; private set; }

        [ForeignKey("AlunoId")]
        public Guid AlunoId { get; private set; }
        public virtual Aluno Aluno { get; private set; }

        public bool Presente { get; private set; }
        public string Observacao { get; private set; }

        protected ChamadaItem() { }

        public ChamadaItem(Guid chamadaId, Guid alunoId, bool presente, string observacao)
        {
            ChamadaId = chamadaId;
            AlunoId = alunoId;
            Presente = presente;
            Observacao = observacao;
        }

        public void AlterarPresenca(bool presente, string observacao)
        {
            Presente = presente;
            Observacao = observacao;
        }


    }
}
