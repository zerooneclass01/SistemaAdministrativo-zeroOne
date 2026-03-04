using Dominio;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapping
{
    public class ChamadaItemMapping : IEntityTypeConfiguration<ChamadaItem>
    {
        public void Configure(EntityTypeBuilder<ChamadaItem> builder)
        {
            builder.ToTable("ChamadaItems");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Presente)
                .IsRequired();

            builder.Property(ci => ci.Observacao)
                .HasColumnType("varchar(250)");

            builder.HasOne(ci => ci.Chamada)       
                       .WithMany(c => c.AlunosPresenca) 
                       .HasForeignKey(ci => ci.ChamadaId) 
                       .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Aluno)
                .WithMany() 
                .HasForeignKey(ci => ci.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
