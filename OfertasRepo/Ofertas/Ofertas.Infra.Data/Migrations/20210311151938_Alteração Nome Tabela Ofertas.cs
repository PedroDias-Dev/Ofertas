using Microsoft.EntityFrameworkCore.Migrations;

namespace Ofertas.Infra.Data.Migrations
{
    public partial class AlteraçãoNomeTabelaOfertas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_TipoCategoria_OfertaId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCategoria",
                table: "TipoCategoria");

            migrationBuilder.RenameTable(
                name: "TipoCategoria",
                newName: "Ofertas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ofertas",
                table: "Ofertas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Ofertas_OfertaId",
                table: "Reservas",
                column: "OfertaId",
                principalTable: "Ofertas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Ofertas_OfertaId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ofertas",
                table: "Ofertas");

            migrationBuilder.RenameTable(
                name: "Ofertas",
                newName: "TipoCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCategoria",
                table: "TipoCategoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_TipoCategoria_OfertaId",
                table: "Reservas",
                column: "OfertaId",
                principalTable: "TipoCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
