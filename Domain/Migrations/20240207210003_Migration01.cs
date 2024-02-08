using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinilProjeto.Migrations
{
    /// <inheritdoc />
    public partial class Migration01 : Migration
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
                    telefonecodigo = table.Column<string>(name: "telefone_codigo", type: "text", nullable: false),
                    telefoneddd = table.Column<string>(name: "telefone_ddd", type: "text", nullable: false),
                    telefonenumero = table.Column<string>(name: "telefone_numero", type: "text", nullable: false),
                    enderecocep = table.Column<string>(name: "endereco_cep", type: "text", nullable: false),
                    enderecologradouro = table.Column<string>(name: "endereco_logradouro", type: "text", nullable: false),
                    endereconumero = table.Column<string>(name: "endereco_numero", type: "text", nullable: false),
                    enderecocomplemento = table.Column<string>(name: "endereco_complemento", type: "text", nullable: false),
                    enderecoreferencia = table.Column<string>(name: "endereco_referencia", type: "text", nullable: false),
                    enderecobairro = table.Column<string>(name: "endereco_bairro", type: "text", nullable: false),
                    enderecocidade = table.Column<string>(name: "endereco_cidade", type: "text", nullable: false),
                    enderecoestado = table.Column<string>(name: "endereco_estado", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioComprador", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "UsuarioComprador");
        }
    }
}
