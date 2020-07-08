using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDCore.Migrations
{
    public partial class newFieldInPatiends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FamiliarPhone",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamiliarPhone",
                table: "Clients");
        }
    }
}
