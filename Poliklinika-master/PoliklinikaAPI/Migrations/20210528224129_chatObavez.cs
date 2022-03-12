using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class chatObavez : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChatObavezaID",
                table: "ChatPoruka",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChatPoruka_ChatObavezaID",
                table: "ChatPoruka",
                column: "ChatObavezaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatPoruka_ChatObaveza_ChatObavezaID",
                table: "ChatPoruka",
                column: "ChatObavezaID",
                principalTable: "ChatObaveza",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatPoruka_ChatObaveza_ChatObavezaID",
                table: "ChatPoruka");

            migrationBuilder.DropIndex(
                name: "IX_ChatPoruka_ChatObavezaID",
                table: "ChatPoruka");

            migrationBuilder.DropColumn(
                name: "ChatObavezaID",
                table: "ChatPoruka");
        }
    }
}
