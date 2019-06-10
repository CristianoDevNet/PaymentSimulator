﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                    Valor = table.Column<decimal>(nullable: false)
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
