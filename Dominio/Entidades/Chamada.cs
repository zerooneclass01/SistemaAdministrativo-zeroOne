using Dominio.Entidades.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Chamada : EntityBase.EntityBase
    {
        public Guid TurmaId { get; private set; }
        public virtual Turma Turma { get; private set; }
        public DateTime DataAula { get; private set; }

        public virtual ICollection<ChamadaItem> AlunosPresenca { get; private set; } = new List<ChamadaItem>();

        protected Chamada() { }

        public Chamada(Guid turmaId, DateTime dataAula)
        {
            if (dataAula.Date != DateTime.Today)
            {
                throw new Exception("A data da aula deve ser o dia de hoje.");
            }
           

            TurmaId = turmaId;
            DataAula = dataAula;
        }

        public void AdicionarLinhaPresenca(Guid alunoId, bool presente, string observacao = null)
        {
            AlunosPresenca.Add(new ChamadaItem(this.Id, alunoId, presente, observacao));
        }
    }
}
