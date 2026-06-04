using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapping
{

    public class HistoricoDoAlunoMapping : IEntityTypeConfiguration<HistoricoDoAluno>
    {
        public void Configure(EntityTypeBuilder<HistoricoDoAluno> builder)
        {
            builder.ToTable("HistoricosDosAlunos");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Descricao)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(h => h.DataAtualizacao)
                .IsRequired(false);

            builder.Property(h => h.StatusComportamento)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(h => h.StatusDesempenho)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(h => h.Aluno)
                .WithMany()
                .HasForeignKey(h => h.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.Professor)
                .WithMany()
                .HasForeignKey(h => h.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
