using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class chat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatObaveza",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObavezaID = table.Column<int>(type: "int", nullable: false),
                    OsobljeID = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatObaveza", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChatObaveza_AspNetUsers_AdminID",
                        column: x => x.AdminID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatObaveza_AspNetUsers_OsobljeID",
                        column: x => x.OsobljeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ChatObaveza_Obaveza_ObavezaID",
                        column: x => x.ObavezaID,
                        principalTable: "Obaveza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChatPoruka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobljeID = table.Column<int>(type: "int", nullable: false),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatPoruka", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChatPoruka_AspNetUsers_OsobljeID",
                        column: x => x.OsobljeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatObaveza_AdminID",
                table: "ChatObaveza",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatObaveza_ObavezaID",
                table: "ChatObaveza",
                column: "ObavezaID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatObaveza_OsobljeID",
                table: "ChatObaveza",
                column: "OsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatPoruka_OsobljeID",
                table: "ChatPoruka",
                column: "OsobljeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatObaveza");

            migrationBuilder.DropTable(
                name: "ChatPoruka");
        }
    }
}
