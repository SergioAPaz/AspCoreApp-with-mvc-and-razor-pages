using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CT_Roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<long>(nullable: false),
                    Names = table.Column<string>(nullable: false),
                    LastNames = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Rfc = table.Column<string>(nullable: true),
                    Calle = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Colonia = table.Column<string>(nullable: true),
                    CP = table.Column<string>(nullable: true),
                    FamiliarPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CT_Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Role = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAccess = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nombres = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Especialidad = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    NoCedula = table.Column<long>(nullable: true),
                    ImgPath = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_CT_Users_CT_Roles",
                        column: x => x.Role,
                        principalTable: "CT_Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_Users_Role",
                table: "CT_Users",
                column: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_Users");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "CT_Roles");
        }
    }
}
