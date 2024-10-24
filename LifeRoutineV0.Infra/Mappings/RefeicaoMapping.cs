using LifeRoutineV0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeRoutineV0.Infra.Mappings;

public class RefeicaoMapping : IEntityTypeConfiguration<Refeicao>
{
    public void Configure(EntityTypeBuilder<Refeicao> builder)
    {
        builder.ToTable("Refeicao");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.DataDeCriacao)
            .HasColumnName("DataDeCriacao")
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.Property(x => x.FichaAlimentacaoId)
            .HasColumnName("FichaAlimentacaoId")
            .HasColumnType("INT");

        builder.HasMany(x => x.Alimentos)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>
            ("RefeicaoAlimento",
            refeicao => refeicao.HasOne<Alimento>().WithMany()
            .HasForeignKey("RefeicaoId").HasConstraintName("FK_Refeicao_Alimentos")
            .OnDelete(DeleteBehavior.Cascade),
            alimento => alimento.HasOne<Refeicao>().WithMany()
            .HasForeignKey("AlimentoId").HasConstraintName("FK_Alimentos_Refeicao")
            .OnDelete(DeleteBehavior.Cascade));
    }
}
