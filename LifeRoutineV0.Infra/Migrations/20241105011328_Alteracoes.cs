using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeRoutineV0.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Alteracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_FichaAlimentacao_FichaAlimentacaoId",
                table: "Refeicao");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaAlimentacao_Refeicoes",
                table: "Refeicao",
                column: "FichaAlimentacaoId",
                principalTable: "FichaAlimentacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaAlimentacao_Refeicoes",
                table: "Refeicao");

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicao_FichaAlimentacao_FichaAlimentacaoId",
                table: "Refeicao",
                column: "FichaAlimentacaoId",
                principalTable: "FichaAlimentacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
