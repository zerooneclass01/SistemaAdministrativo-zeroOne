using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Professor :EntityBase.EntityBase
    {
        public string Nome { get; private set; }
        public decimal Salario {  get;private set; }

        public ICollection<Turma> Turmas { get; set; }

        public Professor()
        {
            
        }

        public Professor(string nome , decimal salario)
        {
            InserirDados(nome, salario);
        }

        public void InserirDados (string nome , decimal salario)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("Nome não pode ser vazio");

            if (salario < 0) throw new ArgumentOutOfRangeException("Salario não pode ser menor que zero");

            Nome = nome;
            Salario = salario;
        }
    }
}
