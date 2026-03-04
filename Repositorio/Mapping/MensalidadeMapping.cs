using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapping
{
    public class MensalidadeMapping : IEntityTypeConfiguration<Mensalidade>
    {
        public void Configure(EntityTypeBuilder<Mensalidade> builder)
        {
            builder.ToTable("Mensalidades");

            // 1. Chave da Mensalidade (ID único dela)
            builder.HasKey(m => m.Id);

            // 2. Relacionamento Unidirecional (A mensalidade não "vê" o Aluno)
            builder.HasOne<Aluno>()
                .WithMany(a => a.Mensalidades)
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3. Outras propriedades
            builder.Property(m => m.ValorOriginal).HasPrecision(18, 2).IsRequired();
            builder.Property(m => m.DataVencimento).IsRequired();
            builder.Property(m => m.PagamentoStatus).IsRequired();
        }
    }
}