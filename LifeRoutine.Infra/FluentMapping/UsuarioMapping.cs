namespace LifeRoutine.Infra.FluentMapping;

using LifeRoutine.Domain;
using LifeRoutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(x => x.Email)
            .Property(x => x.EnderecoDeEmail)
            .HasColumnName("EnderecoDeEmail")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120)
            .IsRequired();

        builder.OwnsOne(x => x.Senha)
            .Property(x => x.SenhaHash)
            .HasColumnName("SenhaHash")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.DataNascimento)
            .HasColumnName("DataNascimento")
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.HasOne(x => x.FichaAlimentacao)
            .WithOne(x => x.Usuario)
            .HasForeignKey<FichaAlimentacao>(x => x.UsuarioId)
            .HasConstraintName("FK_FichaAlimentacao_Usuario")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(x => x.FichasExercicios)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId)
            .IsRequired(false);

        builder.HasMany(x => x.FichasCorporal)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId)
            .IsRequired(false);
    }
}