using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace saborna_crkva_API.Migrations
{
    public partial class AddObavjestenjaKategorijeObavjestenja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObavjestenjaKategorijeObavjestenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ObavjestenjaKategorijeID = table.Column<int>(nullable: false),
                    ObavjestenjaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObavjestenjaKategorijeObavjestenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObavjestenjaKategorijeObavjestenja_Obavjestenja_ObavjestenjaID",
                        column: x => x.ObavjestenjaID,
                        principalTable: "Obavjestenja",
                        principalColumn: "ObavjestenjaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ObavjestenjaKategorijeObavjestenja_ObavjestenjaKategorije_ObavjestenjaKategorijeID",
                        column: x => x.ObavjestenjaKategorijeID,
                        principalTable: "ObavjestenjaKategorije",
                        principalColumn: "ObavjestenjaKategorijeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObavjestenjaKategorijeObavjestenja_ObavjestenjaID",
                table: "ObavjestenjaKategorijeObavjestenja",
                column: "ObavjestenjaID");

            migrationBuilder.CreateIndex(
                name: "IX_ObavjestenjaKategorijeObavjestenja_ObavjestenjaKategorijeID",
                table: "ObavjestenjaKategorijeObavjestenja",
                column: "ObavjestenjaKategorijeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObavjestenjaKategorijeObavjestenja");
        }
    }
}
