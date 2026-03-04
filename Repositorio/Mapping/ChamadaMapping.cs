using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapping
{
    public class ChamadaMapping : IEntityTypeConfiguration<Chamada>
    {
        public void Configure(EntityTypeBuilder<Chamada> builder)
        {
            builder.ToTable("Chamadas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataAula)
                .IsRequired();

            // Relacionamento com Turma
            builder.HasOne(c => c.Turma)
                .WithMany() // Uma turma pode ter muitas chamadas
                .HasForeignKey(c => c.TurmaId)
                .OnDelete(DeleteBehavior.Cascade);

            // ÍNDICE ÚNICO: Impede duplicidade de chamada para a mesma turma no mesmo dia
            builder.HasIndex(c => new { c.TurmaId, c.DataAula })
                .IsUnique();
        }
    }
}