using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class adiconandchamada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiasDaAula",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chamadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamadas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamadaItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChamadaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Presente = table.Column<bool>(type: "bit", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(250)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamadaItems_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChamadaItems_Chamadas_ChamadaId",
                        column: x => x.ChamadaId,
                        principalTable: "Chamadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChamadaItems_AlunoId",
                table: "ChamadaItems",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadaItems_ChamadaId",
                table: "ChamadaItems",
                column: "ChamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamadas_TurmaId_DataAula",
                table: "Chamadas",
                columns: new[] { "TurmaId", "DataAula" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamadaItems");

            migrationBuilder.DropTable(
                name: "Chamadas");

            migrationBuilder.DropColumn(
                name: "DiasDaAula",
                table: "Turmas");
        }
    }
}
