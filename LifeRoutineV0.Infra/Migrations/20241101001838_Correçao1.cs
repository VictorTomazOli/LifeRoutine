using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeRoutineV0.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Correçao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_Refeicao",
                table: "RefeicaoAlimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_Alimentos",
                table: "RefeicaoAlimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_Refeicao",
                table: "RefeicaoAlimento",
                column: "RefeicaoId",
                principalTable: "Refeicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicao_Alimentos",
                table: "RefeicaoAlimento",
                column: "AlimentoId",
                principalTable: "Alimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimentos_Refeicao",
                table: "RefeicaoAlimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Refeicao_Alimentos",
                table: "RefeicaoAlimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimentos_Refeicao",
                table: "RefeicaoAlimento",
                column: "AlimentoId",
                principalTable: "Refeicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Refeicao_Alimentos",
                table: "RefeicaoAlimento",
                column: "RefeicaoId",
                principalTable: "Alimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
