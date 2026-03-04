using Dominio.Entidades;
using Repositorio.Data;
using Repositorio.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repository
{
    public class ProfessorRepository : RepositoryBase<Professor> ,IProfessoRepository
    {
        private readonly Contexto _contexto;

        public ProfessorRepository(Contexto contexto): base(contexto) 
        {
            _contexto = contexto;
        }
    }
}
