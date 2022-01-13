using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistemaRH.Data.Migrations
{
    public partial class setor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.IdSetor);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.IdCargo);
                    table.ForeignKey(
                        name: "FK_Cargo_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Admissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Salario = table.Column<float>(type: "REAL", nullable: false),
                    Gestor = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdSetor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCargo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Colaborador_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_IdSetor",
                table: "Cargo",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_IdCargo",
                table: "Colaborador",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_IdSetor",
                table: "Colaborador",
                column: "IdSetor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Setor");
        }
    }
}
