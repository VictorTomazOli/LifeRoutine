using LifeRoutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeRoutine.Infra.FluentMapping;

public class FichaExercicioMapping : IEntityTypeConfiguration<FichaExercicio>
{
    public void Configure(EntityTypeBuilder<FichaExercicio> builder)
    {
        builder.ToTable("FichaExercicio");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Guid)
            .HasColumnName("Guid")
            .HasColumnType("BLOB")
            .IsRequired();

        builder.Property(x => x.DataCriacao)
            .HasColumnName("DataCriacao")
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.OwnsMany(x => x.Exercicios)
            .Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsMany(x => x.Exercicios)
            .Property(x => x.Numero_De_Repeticoes)
            .HasColumnName("Numero_De_Repeticoes")
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder.OwnsMany(x => x.Exercicios)
            .Property(x => x.Numero_De_Series)
            .HasColumnName("Numero_De_Series")
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder.OwnsMany(x => x.Exercicios)
            .Property(x => x.DiasDaSemana)
            .HasColumnName("Dias_Da_Semana")
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .HasColumnName("UsuarioId")
            .HasColumnType("Usuario")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.FichasExercicios)
            .HasConstraintName("FK_FichasExercicios_Usuario")
            .IsRequired();
    }
}