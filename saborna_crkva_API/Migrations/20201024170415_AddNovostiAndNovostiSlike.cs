using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saborna_crkva_API.Migrations
{
    public partial class AddNovostiAndNovostiSlike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Novosti",
                columns: table => new
                {
                    NovostiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    DatumObjavljivanja = table.Column<DateTime>(nullable: false),
                    Naslov = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novosti", x => x.NovostiID);
                });

            migrationBuilder.CreateTable(
                name: "NovostiSlike",
                columns: table => new
                {
                    NovostiSlikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NovostiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovostiSlike", x => x.NovostiSlikeID);
                    table.ForeignKey(
                        name: "FK_NovostiSlike_Novosti_NovostiID",
                        column: x => x.NovostiID,
                        principalTable: "Novosti",
                        principalColumn: "NovostiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovostiSlike_NovostiID",
                table: "NovostiSlike",
                column: "NovostiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovostiSlike");

            migrationBuilder.DropTable(
                name: "Novosti");
        }
    }
}
