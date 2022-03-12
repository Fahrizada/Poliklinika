using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class timespanstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_AspNetUsers_OsobljeID",
                table: "Raspored");

            migrationBuilder.DropTable(
                name: "PregledTehnicar");

            migrationBuilder.DropTable(
                name: "RasporedOsoblje");

            migrationBuilder.RenameColumn(
                name: "OsobljeID",
                table: "Raspored",
                newName: "TehnicarID");

            migrationBuilder.RenameIndex(
                name: "IX_Raspored_OsobljeID",
                table: "Raspored",
                newName: "IX_Raspored_TehnicarID");

            migrationBuilder.AlterColumn<string>(
                name: "Vrijeme",
                table: "Raspored",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<int>(
                name: "DoktorID",
                table: "Raspored",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Raspored_DoktorID",
                table: "Raspored",
                column: "DoktorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_AspNetUsers_DoktorID",
                table: "Raspored",
                column: "DoktorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_AspNetUsers_TehnicarID",
                table: "Raspored",
                column: "TehnicarID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_AspNetUsers_DoktorID",
                table: "Raspored");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_AspNetUsers_TehnicarID",
                table: "Raspored");

            migrationBuilder.DropIndex(
                name: "IX_Raspored_DoktorID",
                table: "Raspored");

            migrationBuilder.DropColumn(
                name: "DoktorID",
                table: "Raspored");

            migrationBuilder.RenameColumn(
                name: "TehnicarID",
                table: "Raspored",
                newName: "OsobljeID");

            migrationBuilder.RenameIndex(
                name: "IX_Raspored_TehnicarID",
                table: "Raspored",
                newName: "IX_Raspored_OsobljeID");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Vrijeme",
                table: "Raspored",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PregledTehnicar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PregledID = table.Column<int>(type: "int", nullable: false),
                    TehnicarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregledTehnicar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PregledTehnicar_AspNetUsers_TehnicarID",
                        column: x => x.TehnicarID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PregledTehnicar_Pregled_PregledID",
                        column: x => x.PregledID,
                        principalTable: "Pregled",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RasporedOsoblje",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobljeID = table.Column<int>(type: "int", nullable: false),
                    RasporedID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasporedOsoblje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RasporedOsoblje_AspNetUsers_OsobljeID",
                        column: x => x.OsobljeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RasporedOsoblje_Raspored_RasporedID",
                        column: x => x.RasporedID,
                        principalTable: "Raspored",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PregledTehnicar_PregledID",
                table: "PregledTehnicar",
                column: "PregledID");

            migrationBuilder.CreateIndex(
                name: "IX_PregledTehnicar_TehnicarID",
                table: "PregledTehnicar",
                column: "TehnicarID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedOsoblje_OsobljeID",
                table: "RasporedOsoblje",
                column: "OsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedOsoblje_RasporedID",
                table: "RasporedOsoblje",
                column: "RasporedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_AspNetUsers_OsobljeID",
                table: "Raspored",
                column: "OsobljeID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
