using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class ChatObavezaObaveza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Obaveza",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "ChatObavezaID",
                table: "Obaveza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obaveza_ChatObavezaID",
                table: "Obaveza",
                column: "ChatObavezaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obaveza_ChatObaveza_ChatObavezaID",
                table: "Obaveza",
                column: "ChatObavezaID",
                principalTable: "ChatObaveza",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obaveza_ChatObaveza_ChatObavezaID",
                table: "Obaveza");

            migrationBuilder.DropIndex(
                name: "IX_Obaveza_ChatObavezaID",
                table: "Obaveza");

            migrationBuilder.DropColumn(
                name: "ChatObavezaID",
                table: "Obaveza");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Obaveza",
                newName: "Id");
        }
    }
}
