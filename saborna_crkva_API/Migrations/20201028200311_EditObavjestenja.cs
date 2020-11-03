using Microsoft.EntityFrameworkCore.Migrations;

namespace saborna_crkva_API.Migrations
{
    public partial class EditObavjestenja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obavjestenja_ObavjestenjaKategorije_ObavjestenjaKategorijeID",
                table: "Obavjestenja");

            migrationBuilder.DropIndex(
                name: "IX_Obavjestenja_ObavjestenjaKategorijeID",
                table: "Obavjestenja");

            migrationBuilder.DropColumn(
                name: "ObavjestenjaKategorijeID",
                table: "Obavjestenja");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObavjestenjaKategorijeID",
                table: "Obavjestenja",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obavjestenja_ObavjestenjaKategorijeID",
                table: "Obavjestenja",
                column: "ObavjestenjaKategorijeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavjestenja_ObavjestenjaKategorije_ObavjestenjaKategorijeID",
                table: "Obavjestenja",
                column: "ObavjestenjaKategorijeID",
                principalTable: "ObavjestenjaKategorije",
                principalColumn: "ObavjestenjaKategorijeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
