using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliklinikaAPI.Migrations
{
    public partial class konsultacije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konsultacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konsultacije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Konsultacije_AspNetUsers_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konsultacije_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KonsultacijePoruka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonsultacijeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonsultacijePoruka", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KonsultacijePoruka_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KonsultacijePoruka_Konsultacije_KonsultacijeID",
                        column: x => x.KonsultacijeID,
                        principalTable: "Konsultacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konsultacije_DoktorID",
                table: "Konsultacije",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Konsultacije_KorisnikID",
                table: "Konsultacije",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KonsultacijePoruka_KonsultacijeID",
                table: "KonsultacijePoruka",
                column: "KonsultacijeID");

            migrationBuilder.CreateIndex(
                name: "IX_KonsultacijePoruka_UserID",
                table: "KonsultacijePoruka",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KonsultacijePoruka");

            migrationBuilder.DropTable(
                name: "Konsultacije");
        }
    }
}
