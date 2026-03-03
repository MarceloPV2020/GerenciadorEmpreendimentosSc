using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorEmpreendimentosSc.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empreendimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeEmpreendimento = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    NomeEmpreendedor = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Municipio = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Segmento = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreendimentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empreendimentos_Municipio",
                table: "Empreendimentos",
                column: "Municipio");

            migrationBuilder.CreateIndex(
                name: "IX_Empreendimentos_Segmento",
                table: "Empreendimentos",
                column: "Segmento");

            migrationBuilder.CreateIndex(
                name: "IX_Empreendimentos_Status",
                table: "Empreendimentos",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empreendimentos");
        }
    }
}
