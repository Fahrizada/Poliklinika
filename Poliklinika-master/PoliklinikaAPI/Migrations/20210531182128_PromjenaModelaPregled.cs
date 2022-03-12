using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class PromjenaModelaPregled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorID",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_TehnicarID",
                table: "Pregled");

            migrationBuilder.AlterColumn<int>(
                name: "TehnicarID",
                table: "Pregled",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoktorID",
                table: "Pregled",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorID",
                table: "Pregled",
                column: "DoktorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_TehnicarID",
                table: "Pregled",
                column: "TehnicarID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorID",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_TehnicarID",
                table: "Pregled");

            migrationBuilder.AlterColumn<int>(
                name: "TehnicarID",
                table: "Pregled",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoktorID",
                table: "Pregled",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorID",
                table: "Pregled",
                column: "DoktorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_TehnicarID",
                table: "Pregled",
                column: "TehnicarID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
