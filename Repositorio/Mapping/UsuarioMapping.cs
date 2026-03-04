using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            // Chave primária
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(u => u.SenhaHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Role)
                .HasConversion<string>()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordResetToken)
                .HasMaxLength(100);

            builder.Property(u => u.Ativo)
                .HasDefaultValue(true);
        }
    }
}
