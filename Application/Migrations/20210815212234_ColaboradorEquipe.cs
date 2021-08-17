using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class ColaboradorEquipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColaboradorEquipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorEquipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColaboradorEquipe_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradorEquipe_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorEquipe_ColaboradorId",
                table: "ColaboradorEquipe",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorEquipe_EquipeId",
                table: "ColaboradorEquipe",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorEquipe");
        }
    }
}
