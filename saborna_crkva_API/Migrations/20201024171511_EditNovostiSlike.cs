using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saborna_crkva_API.Migrations
{
    public partial class EditNovostiSlike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Slika",
                table: "NovostiSlike",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "NovostiSlike");
        }
    }
}
