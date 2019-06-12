using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace simulator_back_end.Migrations
{
    public partial class Renovable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Juros = table.Column<decimal>(nullable: false),
                    DataDaCompra = table.Column<DateTime>(nullable: false),
                    ValorDaCompra = table.Column<decimal>(nullable: false),
                    QuantidadeDeParcelas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulacoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha" },
                values: new object[] { 1, "abc@abc.com", "123" });

            migrationBuilder.InsertData(
                table: "Simulacoes",
                columns: new[] { "Id", "DataDaCompra", "Juros", "QuantidadeDeParcelas", "Titulo", "UsuarioId", "ValorDaCompra" },
                values: new object[] { 1, new DateTime(2019, 6, 12, 12, 54, 19, 276, DateTimeKind.Local).AddTicks(1511), 4.12m, 4, "Fiat Uno Vivace", 1, 25694.23m });

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_UsuarioId",
                table: "Simulacoes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
