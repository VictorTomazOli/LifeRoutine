using LifeRoutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeRoutine.Infra.FluentMapping;

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

        builder.HasMany(x => x.Alimentos)
            .WithOne()
            .HasConstraintName("FK_Refeicao_Alimentos")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}