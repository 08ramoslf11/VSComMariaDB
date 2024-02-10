using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VSComMariaDB.Migrations
{
    /// <inheritdoc />
    public partial class AlterarNomeCampoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produto",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produto",
                newName: "Name");
        }
    }
}
