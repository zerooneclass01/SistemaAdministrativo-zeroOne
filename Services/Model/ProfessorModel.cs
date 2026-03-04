using Dominio.Entidades;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class ProfessorModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public decimal Salario { get; set; }
        public List<TurmaModel> Turmas { get; set; }

        public int QuantidadeTurmas { get; set; }

        public ProfessorModel Response(Professor professor)
        {
            if (professor == null)
                return null;

            Id = professor.Id;
            Nome = professor.Nome;
            Salario = professor.Salario;
            if (professor.Turmas != null && professor.Turmas.Any())
            {
                Turmas = professor.Turmas.Select(t => new TurmaModel
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    Horario = t.Horario

                }).ToList();

                QuantidadeTurmas = professor.Turmas.Count();
            }
            else
            {
                Turmas = new List<TurmaModel>();
                QuantidadeTurmas = 0;
            }

            return this;
        }
    }
}
