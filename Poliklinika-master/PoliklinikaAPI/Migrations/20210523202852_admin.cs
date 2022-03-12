using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zanimanje",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Obaveza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobljeID = table.Column<int>(type: "int", nullable: false),
                    OdjelID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obaveza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obaveza_AspNetUsers_OsobljeID",
                        column: x => x.OsobljeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obaveza_Odjel_OdjelID",
                        column: x => x.OdjelID,
                        principalTable: "Odjel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obaveza_OdjelID",
                table: "Obaveza",
                column: "OdjelID");

            migrationBuilder.CreateIndex(
                name: "IX_Obaveza_OsobljeID",
                table: "Obaveza",
                column: "OsobljeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obaveza");

            migrationBuilder.AddColumn<string>(
                name: "Zanimanje",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
