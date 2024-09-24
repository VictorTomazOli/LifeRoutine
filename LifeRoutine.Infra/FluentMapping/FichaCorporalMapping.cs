using LifeRoutine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LifeRoutine.Infra.FluentMapping;

public class FichaCorporalMapping : IEntityTypeConfiguration<FichaCorporal>
{
    public void Configure(EntityTypeBuilder<FichaCorporal> builder)
    {
        builder.ToTable("FichaCorporal");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Guid)
            .HasColumnName("Guid")
            .HasColumnType("BLOB")
            .IsRequired();

        builder.Property(x => x.Peso)
            .HasColumnName("Peso")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.Property(x => x.Altura)
            .HasColumnName("Altura")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.Property(x => x.DataCriacao)
            .HasColumnName("DataCriacao")
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Ombro)
            .HasColumnName("Ombro")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Torax)
            .HasColumnName("Torax")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Cintura)
            .HasColumnName("Cintura")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Abdome)
            .HasColumnName("Abdome")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Quadril)
            .HasColumnName("Quadril")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Braço_Direito)
            .HasColumnName("Braco_Direito")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Braço_Esquerdo)
            .HasColumnName("Braco_Esquerdo")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.AnteBraço_Direito)
            .HasColumnName("AnteBraco_Direito")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.AnteBraço_Esquerdo)
            .HasColumnName("AnteBraco_Esquerdo")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Coxa_Direita)
            .HasColumnName("Coxa_Direita")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Coxa_Esquerda)
            .HasColumnName("Coxa_Esquerda")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Panturrilha_Direita)
            .HasColumnName("Panturrilha_Direita")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.OwnsOne(x => x.Perimetria)
            .Property(x => x.Panturrilha_Esquerda)
            .HasColumnName("Panturrilha_Esquerda")
            .HasColumnType("FLOAT")
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .HasColumnName("UsuarioId")
            .HasColumnType("Usuario")
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.FichasCorporal)
            .HasConstraintName("FK_FichasCorporal_Usuario")
            .IsRequired();
    }
}