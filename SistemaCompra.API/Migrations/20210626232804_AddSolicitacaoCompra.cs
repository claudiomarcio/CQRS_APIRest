using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AddSolicitacaoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("80bd60d7-28f8-4ea5-9222-302c193b17d4"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao", "Preco" },
                values: new object[] { new Guid("c4a5d646-3a99-473e-af1a-7be0526c7f02"), 1, "Descricao01", "Produto01", 1, 100m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("c4a5d646-3a99-473e-af1a-7be0526c7f02"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Situacao", "Preco" },
                values: new object[] { new Guid("80bd60d7-28f8-4ea5-9222-302c193b17d4"), 1, "Descricao01", "Produto01", 1, 100m });
        }
    }
}
