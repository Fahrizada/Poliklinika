using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class remoceChatObavezaObaveza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
