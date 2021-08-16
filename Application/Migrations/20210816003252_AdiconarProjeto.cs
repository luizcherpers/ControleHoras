using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class AdiconarProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projeto",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("c286cad8-6681-4a89-bef6-bf3c0097d9a7"), "Projeto Teste 01" });

            migrationBuilder.InsertData(
                table: "Projeto",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("50953752-09b2-41e5-9b3e-52477cf45aea"), "Projeto Teste 02" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
