﻿// <auto-generated />
using System;
using LifeRoutineV0.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LifeRoutineV0.Infra.Migrations
{
    [DbContext(typeof(LifeRoutineV0DbContext))]
    [Migration("20241022231631_PrimeiraMigracao")]
    partial class PrimeiraMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.Alimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("GrupoAlimentar")
                        .HasColumnType("SMALLINT")
                        .HasColumnName("GrupoAlimentar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Alimento", (string)null);
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.FichaAlimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INT")
                        .HasColumnName("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("FichaAlimentacao", (string)null);
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.Refeicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("DataDeCriacao");

                    b.Property<int>("FichaAlimentacaoId")
                        .HasColumnType("INT")
                        .HasColumnName("FichaAlimentacaoId");

                    b.HasKey("Id");

                    b.HasIndex("FichaAlimentacaoId");

                    b.ToTable("Refeicao", (string)null);
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("DataNascimento");

                    b.Property<int>("FichaAlimentacaoId")
                        .HasColumnType("INT")
                        .HasColumnName("FichaAlimentacaoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("RefeicaoAlimento", b =>
                {
                    b.Property<int>("AlimentoId")
                        .HasColumnType("int");

                    b.Property<int>("RefeicaoId")
                        .HasColumnType("int");

                    b.HasKey("AlimentoId", "RefeicaoId");

                    b.HasIndex("RefeicaoId");

                    b.ToTable("RefeicaoAlimento");
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.FichaAlimentacao", b =>
                {
                    b.HasOne("LifeRoutineV0.Domain.Entities.Usuario", "Usuario")
                        .WithOne("FichaAlimentacao")
                        .HasForeignKey("LifeRoutineV0.Domain.Entities.FichaAlimentacao", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.Refeicao", b =>
                {
                    b.HasOne("LifeRoutineV0.Domain.Entities.FichaAlimentacao", null)
                        .WithMany("Refeicoes")
                        .HasForeignKey("FichaAlimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.Usuario", b =>
                {
                    b.OwnsOne("LifeRoutineV0.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("EnderecoDeEmail")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("EnderecoDeEmail");

                            b1.HasKey("UsuarioId");

                            b1.HasIndex("EnderecoDeEmail")
                                .IsUnique();

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LifeRoutineV0.Domain.ValueObjects.Senha", "Senha", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("SenhaHash")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("SenhaHash");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Senha")
                        .IsRequired();
                });

            modelBuilder.Entity("RefeicaoAlimento", b =>
                {
                    b.HasOne("LifeRoutineV0.Domain.Entities.Refeicao", null)
                        .WithMany()
                        .HasForeignKey("AlimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Alimentos_Refeicao");

                    b.HasOne("LifeRoutineV0.Domain.Entities.Alimento", null)
                        .WithMany()
                        .HasForeignKey("RefeicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Refeicao_Alimentos");
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.FichaAlimentacao", b =>
                {
                    b.Navigation("Refeicoes");
                });

            modelBuilder.Entity("LifeRoutineV0.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("FichaAlimentacao")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
