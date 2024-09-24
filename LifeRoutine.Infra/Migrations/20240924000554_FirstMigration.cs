using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeRoutine.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FichaAlimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaAlimentacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDeCriacao = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    FichaAlimentacaoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refeicao_FichaAlimentacao_FichaAlimentacaoId",
                        column: x => x.FichaAlimentacaoId,
                        principalTable: "FichaAlimentacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    EnderecoDeEmail = table.Column<string>(type: "NVARCHAR", maxLength: 120, nullable: false),
                    SenhaHash = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    FichaAlimentacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaAlimentacao_Usuario",
                        column: x => x.FichaAlimentacaoId,
                        principalTable: "FichaAlimentacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    GrupoAlimentar = table.Column<int>(type: "SMALLINT", nullable: false),
                    RefeicaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refeicao_Alimentos",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaCorporal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "Usuario", nullable: false),
                    Guid = table.Column<Guid>(type: "BLOB", nullable: false),
                    Peso = table.Column<float>(type: "FLOAT", nullable: false),
                    Altura = table.Column<float>(type: "FLOAT", nullable: false),
                    Ombro = table.Column<float>(type: "FLOAT", nullable: true),
                    Torax = table.Column<float>(type: "FLOAT", nullable: true),
                    Cintura = table.Column<float>(type: "FLOAT", nullable: true),
                    Abdome = table.Column<float>(type: "FLOAT", nullable: true),
                    Quadril = table.Column<float>(type: "FLOAT", nullable: true),
                    Braco_Direito = table.Column<float>(type: "FLOAT", nullable: true),
                    Braco_Esquerdo = table.Column<float>(type: "FLOAT", nullable: true),
                    AnteBraco_Direito = table.Column<float>(type: "FLOAT", nullable: true),
                    AnteBraco_Esquerdo = table.Column<float>(type: "FLOAT", nullable: true),
                    Coxa_Direita = table.Column<float>(type: "FLOAT", nullable: true),
                    Coxa_Esquerda = table.Column<float>(type: "FLOAT", nullable: true),
                    Panturrilha_Direita = table.Column<float>(type: "FLOAT", nullable: true),
                    Panturrilha_Esquerda = table.Column<float>(type: "FLOAT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaCorporal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasCorporal_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaExercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Guid = table.Column<Guid>(type: "BLOB", nullable: false),
                    UsuarioId = table.Column<int>(type: "Usuario", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaExercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasExercicios_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    FichaExercicioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    Numero_De_Repeticoes = table.Column<int>(type: "SMALLINT", nullable: false),
                    Numero_De_Series = table.Column<int>(type: "SMALLINT", nullable: false),
                    Dias_Da_Semana = table.Column<string>(type: "SMALLINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => new { x.FichaExercicioId, x.Id });
                    table.ForeignKey(
                        name: "FK_Exercicio_FichaExercicio_FichaExercicioId",
                        column: x => x.FichaExercicioId,
                        principalTable: "FichaExercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_RefeicaoId",
                table: "Alimento",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaCorporal_UsuarioId",
                table: "FichaCorporal",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaExercicio_UsuarioId",
                table: "FichaExercicio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_FichaAlimentacaoId",
                table: "Refeicao",
                column: "FichaAlimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FichaAlimentacaoId",
                table: "Usuario",
                column: "FichaAlimentacaoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "FichaCorporal");

            migrationBuilder.DropTable(
                name: "Refeicao");

            migrationBuilder.DropTable(
                name: "FichaExercicio");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "FichaAlimentacao");
        }
    }
}
