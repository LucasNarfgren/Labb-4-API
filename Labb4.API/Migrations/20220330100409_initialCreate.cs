using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4.API.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(nullable: true),
                    InterestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Adress", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, "Hertings Allé 5A", "Lucas", "Narfgren", "0707409223" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Adress", "FirstName", "LastName", "Phone" },
                values: new object[] { 2, "Kalles Allé 5A", "Johnny", "karlsson", "034534423" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Adress", "FirstName", "LastName", "Phone" },
                values: new object[] { 3, "Svens Allé 5A", "Conny", "Svensson", "098098764" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "PersonId", "Title" },
                values: new object[] { 1, "Spela Golf", 1, "Golf" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "PersonId", "Title" },
                values: new object[] { 2, "Köra Fort", 2, "Racing" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "PersonId", "Title" },
                values: new object[] { 3, "Skjuta vilt", 3, "Skytte" });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "InterestId", "URL" },
                values: new object[] { 1, 1, "https://www.vinbergsgolfklubb.se/" });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "InterestId", "URL" },
                values: new object[] { 2, 2, "https://www.falkenbergsmk.se/" });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "InterestId", "URL" },
                values: new object[] { 3, 3, "https://www.pistolskytteforbundet.se/" });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
