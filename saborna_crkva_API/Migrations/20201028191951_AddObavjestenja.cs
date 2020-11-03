using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saborna_crkva_API.Migrations
{
    public partial class AddObavjestenja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObavjestenjaKategorije",
                columns: table => new
                {
                    ObavjestenjaKategorijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObavjestenjaKategorije", x => x.ObavjestenjaKategorijeID);
                });

            migrationBuilder.CreateTable(
                name: "Obavjestenja",
                columns: table => new
                {
                    ObavjestenjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    DatumObjavljivanja = table.Column<DateTime>(nullable: false),
                    ObavjestenjaKategorijeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavjestenja", x => x.ObavjestenjaID);
                    table.ForeignKey(
                        name: "FK_Obavjestenja_ObavjestenjaKategorije_ObavjestenjaKategorijeID",
                        column: x => x.ObavjestenjaKategorijeID,
                        principalTable: "ObavjestenjaKategorije",
                        principalColumn: "ObavjestenjaKategorijeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObavjestenjaSlike",
                columns: table => new
                {
                    ObavjestenjaSlikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Slika = table.Column<byte[]>(nullable: true),
                    ObavjestenjaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObavjestenjaSlike", x => x.ObavjestenjaSlikeID);
                    table.ForeignKey(
                        name: "FK_ObavjestenjaSlike_Obavjestenja_ObavjestenjaID",
                        column: x => x.ObavjestenjaID,
                        principalTable: "Obavjestenja",
                        principalColumn: "ObavjestenjaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obavjestenja_ObavjestenjaKategorijeID",
                table: "Obavjestenja",
                column: "ObavjestenjaKategorijeID");

            migrationBuilder.CreateIndex(
                name: "IX_ObavjestenjaSlike_ObavjestenjaID",
                table: "ObavjestenjaSlike",
                column: "ObavjestenjaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObavjestenjaSlike");

            migrationBuilder.DropTable(
                name: "Obavjestenja");

            migrationBuilder.DropTable(
                name: "ObavjestenjaKategorije");
        }
    }
}
