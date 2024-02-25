using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinilProjeto.Migrations
{
    /// <inheritdoc />
    public partial class Migration005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Vinil",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nomeVinil = table.Column<string>(type: "text", nullable: false),
                    descricaoVinil = table.Column<string>(type: "text", nullable: false),
                    precoVinil = table.Column<string>(type: "text", nullable: false),
                    quantiaVinil = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinil", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vinil");

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
    }
}
