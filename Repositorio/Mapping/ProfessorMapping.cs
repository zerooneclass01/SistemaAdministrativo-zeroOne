using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapping
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores");

            builder.HasKey(p => p.Id);

            
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Salario)
                .HasPrecision(18, 2) 
                .IsRequired();

           
            builder.HasMany(p => p.Turmas)
                .WithOne(t => t.Professor)
                .HasForeignKey(t => t.ProfessorId) 
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
