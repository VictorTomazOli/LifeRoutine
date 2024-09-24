using LifeRoutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeRoutine.Infra.FluentMapping;

public class AlimentoMapping : IEntityTypeConfiguration<Alimento>
{
    public void Configure(EntityTypeBuilder<Alimento> builder)
    {
        builder.ToTable("Alimento");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.GrupoAlimentar)
            .HasColumnName("GrupoAlimentar")
            .HasColumnType("SMALLINT")
            .IsRequired();
    }
}