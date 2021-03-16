using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ofertas.Infra.Data.Migrations
{
    public partial class Upgradebanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProduto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "Text", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    PrecoAntigo = table.Column<double>(type: "float", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    DisponivelDoacao = table.Column<bool>(type: "bit", nullable: false),
                    EstoqueTotal = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Senha = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOferta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeReserva = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reservas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
