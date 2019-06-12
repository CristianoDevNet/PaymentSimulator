using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace simulator_back_end.Migrations
{
    public partial class FirstMigrations : Migration
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
                name: "SimCabs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Juros = table.Column<decimal>(nullable: false),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimCabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimCabs_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimDets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SimCabId = table.Column<int>(nullable: false),
                    Parcela = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Vencimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimDets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimDets_SimCabs_SimCabId",
                        column: x => x.SimCabId,
                        principalTable: "SimCabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha" },
                values: new object[] { 1, "abc@abc.com", "123" });

            migrationBuilder.InsertData(
                table: "SimCabs",
                columns: new[] { "Id", "Data", "Juros", "Titulo", "UsuarioId" },
                values: new object[] { 1, "11/06/2019", 4.12m, "Fiat Uno Vivace", 1 });

            migrationBuilder.InsertData(
                table: "SimDets",
                columns: new[] { "Id", "Parcela", "SimCabId", "Valor", "Vencimento" },
                values: new object[] { 1, 1, 1, 8234.12m, new DateTime(2019, 7, 11, 20, 58, 42, 667, DateTimeKind.Local).AddTicks(3447) });

            migrationBuilder.InsertData(
                table: "SimDets",
                columns: new[] { "Id", "Parcela", "SimCabId", "Valor", "Vencimento" },
                values: new object[] { 2, 2, 1, 8234.12m, new DateTime(2019, 8, 11, 20, 58, 42, 667, DateTimeKind.Local).AddTicks(3758) });

            migrationBuilder.InsertData(
                table: "SimDets",
                columns: new[] { "Id", "Parcela", "SimCabId", "Valor", "Vencimento" },
                values: new object[] { 3, 3, 1, 8234.12m, new DateTime(2019, 9, 11, 20, 58, 42, 667, DateTimeKind.Local).AddTicks(3765) });

            migrationBuilder.CreateIndex(
                name: "IX_SimCabs_UsuarioId",
                table: "SimCabs",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SimDets_SimCabId",
                table: "SimDets",
                column: "SimCabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimDets");

            migrationBuilder.DropTable(
                name: "SimCabs");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
