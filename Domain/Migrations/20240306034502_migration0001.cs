using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinilProjeto.Migrations
{
    /// <inheritdoc />
    public partial class migration0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioComprador",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    telefone_codigo = table.Column<string>(type: "text", nullable: false),
                    telefone_ddd = table.Column<string>(type: "text", nullable: false),
                    telefone_numero = table.Column<string>(type: "text", nullable: false),
                    endereco_cep = table.Column<string>(type: "text", nullable: false),
                    endereco_logradouro = table.Column<string>(type: "text", nullable: false),
                    endereco_numero = table.Column<string>(type: "text", nullable: false),
                    endereco_complemento = table.Column<string>(type: "text", nullable: false),
                    endereco_referencia = table.Column<string>(type: "text", nullable: false),
                    endereco_bairro = table.Column<string>(type: "text", nullable: false),
                    endereco_cidade = table.Column<string>(type: "text", nullable: false),
                    endereco_estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioComprador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vinil",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nomeVinil = table.Column<string>(type: "text", nullable: false),
                    descricaoVinil = table.Column<string>(type: "text", nullable: false),
                    precoVinil = table.Column<string>(type: "text", nullable: false),
                    quantiaVinil = table.Column<string>(type: "text", nullable: false),
                    EstiloMusical = table.Column<string>(type: "text", nullable: false),
                    StatusVinil = table.Column<int>(type: "integer", nullable: false)
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
                name: "Admin");

            migrationBuilder.DropTable(
                name: "UsuarioComprador");

            migrationBuilder.DropTable(
                name: "Vinil");
        }
    }
}
