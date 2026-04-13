using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Dominio.Entidades
{
    public class Ranking : EntityBase.EntityBase
    {
        public Guid Turmaid { get;private set; }
        public Guid Alunoid  { get;private set; }
        public int Pontos { get;private set; }

        public Ranking()
        {
            
        }

        public void AdicionarAluno(Guid turma, Guid aluno,int pontos)
        {
            Turmaid = turma;
            Alunoid  = aluno;
            Pontos = pontos;
        }

        public void AtualizarPontos(int pontos)
        {
            Pontos = pontos;
        }
    }
}
