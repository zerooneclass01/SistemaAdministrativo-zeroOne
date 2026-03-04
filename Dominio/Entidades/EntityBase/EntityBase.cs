using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades.EntityBase
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }


        public EntityBase()
        {
            Id = Guid.NewGuid();    
            DataCadastro = DateTime.Now;
        }

    }
}
