using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinilProjeto.Migrations
{
    /// <inheritdoc />
    public partial class migracao03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefone_numero",
                table: "UsuarioComprador",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "telefone_ddd",
                table: "UsuarioComprador",
                newName: "ddd");

            migrationBuilder.RenameColumn(
                name: "telefone_codigo",
                table: "UsuarioComprador",
                newName: "codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numero",
                table: "UsuarioComprador",
                newName: "telefone_numero");

            migrationBuilder.RenameColumn(
                name: "ddd",
                table: "UsuarioComprador",
                newName: "telefone_ddd");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "UsuarioComprador",
                newName: "telefone_codigo");
        }
    }
}
