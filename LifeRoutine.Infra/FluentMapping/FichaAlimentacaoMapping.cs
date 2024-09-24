using LifeRoutine.Domain;
using LifeRoutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeRoutine.Infra.FluentMapping;

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
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(x => x.Refeicoes)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}