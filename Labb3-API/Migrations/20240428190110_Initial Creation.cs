using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonInterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.PersonInterestID);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonInterestID = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkID);
                    table.ForeignKey(
                        name: "FK_Links_PersonInterests_PersonInterestID",
                        column: x => x.PersonInterestID,
                        principalTable: "PersonInterests",
                        principalColumn: "PersonInterestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "InterestDescription", "InterestName" },
                values: new object[,]
                {
                    { 1, "Watching the Swedish Football League Allsvenskan.", "Allsvenskan" },
                    { 2, "Going to the gym to lifting heavy weights.", "Gym" },
                    { 3, "Playing games on various platforms, for example computers, consoles and phones.", "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonID", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Isac", "Elfstrand", "0710101010" },
                    { 2, "Anas", "Qlok", "0734567891" },
                    { 3, "Tobias", "Qlok", "0776543210" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonInterestID", "InterestID", "PersonID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkID", "PersonInterestID", "Url" },
                values: new object[,]
                {
                    { 1, 1, "www.fotbollskanalen.se" },
                    { 2, 2, "www.friskissvettis.se" },
                    { 3, 3, "www.store.steampowered.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestID",
                table: "Links",
                column: "PersonInterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestID",
                table: "PersonInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonID",
                table: "PersonInterests",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
