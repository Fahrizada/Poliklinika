using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class UpdateRasporedIPregled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smjena");

            migrationBuilder.DropColumn(
                name: "DatumDO",
                table: "Raspored");

            migrationBuilder.DropColumn(
                name: "Dokument",
                table: "Raspored");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Raspored");

            migrationBuilder.RenameColumn(
                name: "DatumOD",
                table: "Raspored",
                newName: "Datum");

            migrationBuilder.AddColumn<int>(
                name: "OsobljeID",
                table: "Raspored",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PregledID",
                table: "Raspored",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Vrijeme",
                table: "Raspored",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "OdjelID",
                table: "Pregled",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TehnicarID",
                table: "Pregled",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Raspored_OsobljeID",
                table: "Raspored",
                column: "OsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_Raspored_PregledID",
                table: "Raspored",
                column: "PregledID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_OdjelID",
                table: "Pregled",
                column: "OdjelID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_TehnicarID",
                table: "Pregled",
                column: "TehnicarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_TehnicarID",
                table: "Pregled",
                column: "TehnicarID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_Odjel_OdjelID",
                table: "Pregled",
                column: "OdjelID",
                principalTable: "Odjel",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_AspNetUsers_OsobljeID",
                table: "Raspored",
                column: "OsobljeID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_Pregled_PregledID",
                table: "Raspored",
                column: "PregledID",
                principalTable: "Pregled",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_TehnicarID",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_Odjel_OdjelID",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_AspNetUsers_OsobljeID",
                table: "Raspored");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_Pregled_PregledID",
                table: "Raspored");

            migrationBuilder.DropIndex(
                name: "IX_Raspored_OsobljeID",
                table: "Raspored");

            migrationBuilder.DropIndex(
                name: "IX_Raspored_PregledID",
                table: "Raspored");

            migrationBuilder.DropIndex(
                name: "IX_Pregled_OdjelID",
                table: "Pregled");

            migrationBuilder.DropIndex(
                name: "IX_Pregled_TehnicarID",
                table: "Pregled");

            migrationBuilder.DropColumn(
                name: "OsobljeID",
                table: "Raspored");

            migrationBuilder.DropColumn(
                name: "PregledID",
                table: "Raspored");

            migrationBuilder.DropColumn(
                name: "Vrijeme",
                table: "Raspored");

            migrationBuilder.DropColumn(
                name: "OdjelID",
                table: "Pregled");

            migrationBuilder.DropColumn(
                name: "TehnicarID",
                table: "Pregled");

            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Raspored",
                newName: "DatumOD");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumDO",
                table: "Raspored",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Dokument",
                table: "Raspored",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Raspored",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Smjena",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RasporedOsobljeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Smjena_RasporedOsoblje_RasporedOsobljeID",
                        column: x => x.RasporedOsobljeID,
                        principalTable: "RasporedOsoblje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Smjena_RasporedOsobljeID",
                table: "Smjena",
                column: "RasporedOsobljeID");
        }
    }
}
