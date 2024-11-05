using LifeRoutineV0.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeRoutineV0.Infra.Mappings;

public class FichaAlimentacaoMapping : IEntityTypeConfiguration<FichaAlimentacao>
{
    public void Configure(EntityTypeBuilder<FichaAlimentacao> builder)
    {
        builder.ToTable("FichaAlimentacao");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UsuarioId)
            .HasColumnName("UsuarioId")
            .HasColumnType("INT")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithOne(x => x.FichaAlimentacao)
            .HasForeignKey<Usuario>(x => x.FichaAlimentacaoId)
            .IsRequired();

        builder.HasMany(x => x.Refeicoes)
            .WithOne()
            .IsRequired(false)
            .HasForeignKey("FichaAlimentacaoId")
            .HasConstraintName("FK_FichaAlimentacao_Refeicoes")
            .OnDelete(DeleteBehavior.Cascade);
    }
}