using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeRoutineV0.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    GrupoAlimentar = table.Column<short>(type: "SMALLINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    EnderecoDeEmail = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    SenhaHash = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    FichaAlimentacaoId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FichaAlimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaAlimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaAlimentacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeCriacao = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    FichaAlimentacaoId = table.Column<int>(type: "INT", nullable: false)
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
                name: "RefeicaoAlimento",
                columns: table => new
                {
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    RefeicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoAlimento", x => new { x.AlimentoId, x.RefeicaoId });
                    table.ForeignKey(
                        name: "FK_Alimentos_Refeicao",
                        column: x => x.AlimentoId,
                        principalTable: "Refeicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Refeicao_Alimentos",
                        column: x => x.RefeicaoId,
                        principalTable: "Alimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichaAlimentacao_UsuarioId",
                table: "FichaAlimentacao",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Refeicao_FichaAlimentacaoId",
                table: "Refeicao",
                column: "FichaAlimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RefeicaoAlimento_RefeicaoId",
                table: "RefeicaoAlimento",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoDeEmail",
                table: "Usuario",
                column: "EnderecoDeEmail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefeicaoAlimento");

            migrationBuilder.DropTable(
                name: "Refeicao");

            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "FichaAlimentacao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
