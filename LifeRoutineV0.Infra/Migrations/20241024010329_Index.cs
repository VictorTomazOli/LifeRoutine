using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeRoutineV0.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Alimento_Nome",
                table: "Alimento",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Alimento_Nome",
                table: "Alimento");
        }
    }
}
