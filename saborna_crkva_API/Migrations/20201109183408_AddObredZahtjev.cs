using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saborna_crkva_API.Migrations
{
    public partial class AddObredZahtjev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObredKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObredKategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObredZahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ObredKategorijaId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObredZahtjev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObredZahtjev_ObredKategorija_ObredKategorijaId",
                        column: x => x.ObredKategorijaId,
                        principalTable: "ObredKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObredZahtjev_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObredZahtjev_ObredKategorijaId",
                table: "ObredZahtjev",
                column: "ObredKategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObredZahtjev_UserId",
                table: "ObredZahtjev",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObredZahtjev");

            migrationBuilder.DropTable(
                name: "ObredKategorija");
        }
    }
}
