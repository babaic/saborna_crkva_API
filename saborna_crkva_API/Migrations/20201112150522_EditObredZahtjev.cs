using Microsoft.EntityFrameworkCore.Migrations;

namespace saborna_crkva_API.Migrations
{
    public partial class EditObredZahtjev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ObredZahtjev",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ObredZahtjev");
        }
    }
}
