using Dominio;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class ChamadaItemModel
    {
        public Guid Id { get; set; }
        public Guid AlunoId { get; set; }
        public string NomeAluno { get; set; }
        public bool Presente { get; set; }
        public string Observacao { get; set; }
        public DateTime DataAula { get; set; }

        public ChamadaItemModel Responser(ChamadaItem entity)
        {
            if (entity == null) return null;

            return new ChamadaItemModel
            {
                Id = entity.Id,
                AlunoId = entity.AlunoId,
                NomeAluno = entity.Aluno?.Nome ?? "Não carregado",
                Presente = entity.Presente,
                Observacao = entity.Observacao,
                // Graças ao 'virtual Chamada', agora você acessa a data assim:
                DataAula = entity.Chamada != null ? entity.Chamada.DataAula : DateTime.MinValue
            };
        }

    }
}
