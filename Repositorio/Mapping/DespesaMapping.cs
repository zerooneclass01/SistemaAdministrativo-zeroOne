using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapping
{
    public class DespesaMapping : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            // Nome da Tabela
            builder.ToTable("Despesas");

            // Chave Primária (Herdada de EntityBase)
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); 

            builder.Property(x => x.DataVencimento)
                .IsRequired();

            builder.Property(x => x.DataPagamento)
                .IsRequired(false);

            builder.Property(x => x.Pago)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.Categoria)
                .IsRequired()
                .HasConversion<int>(); 
        }
    }
}