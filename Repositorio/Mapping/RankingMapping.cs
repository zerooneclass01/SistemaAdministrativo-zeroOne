using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapping
{
    public class RankingMapping : IEntityTypeConfiguration<Ranking>
    {
        public void Configure(EntityTypeBuilder<Ranking> builder)
        {
            builder.ToTable("Rankings");

            // Chave Primária (Herdada de EntityBase)
            builder.HasKey(r => r.Id);

            // Mapeamento das Propriedades
            builder.Property(r => r.Turmaid)
                .IsRequired()
                .HasColumnName("TurmaId"); // Nome opcional para seguir padrão de FK

            builder.Property(r => r.Alunoid)
                .IsRequired()
                .HasColumnName("AlunoId");

            builder.Property(r => r.Pontos)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasIndex(r => new { r.Turmaid, r.Alunoid })
                .IsUnique();
        }
    }
}
