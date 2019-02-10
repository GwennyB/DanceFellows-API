using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_DanceFellows.Migrations
{
    public partial class initil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    WSDC_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MinLevel = table.Column<int>(nullable: false),
                    MaxLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.WSDC_ID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: true),
                    SeriesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Series_SeriesID",
                        column: x => x.SeriesID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventCompetitions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompType = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCompetitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventCompetitions_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    EventCompetitionID = table.Column<int>(nullable: false),
                    CompetitorID = table.Column<int>(nullable: false),
                    Placement = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    ScoreChief = table.Column<int>(nullable: false),
                    ScoreOne = table.Column<int>(nullable: false),
                    ScoreTwo = table.Column<int>(nullable: false),
                    ScoreThree = table.Column<int>(nullable: false),
                    ScoreFour = table.Column<int>(nullable: false),
                    ScoreFive = table.Column<int>(nullable: false),
                    ScoreSix = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => new { x.EventCompetitionID, x.CompetitorID });
                    table.ForeignKey(
                        name: "FK_Results_Competitors_CompetitorID",
                        column: x => x.CompetitorID,
                        principalTable: "Competitors",
                        principalColumn: "WSDC_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_EventCompetitions_EventCompetitionID",
                        column: x => x.EventCompetitionID,
                        principalTable: "EventCompetitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "WSDC_ID", "FirstName", "ID", "LastName", "MaxLevel", "MinLevel" },
                values: new object[,]
                {
                    { 8717, "David", 1, "Buchthal", 3, 2 },
                    { 14007, "Gwen", 2, "Zubatch", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "ID", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Bellevue, WA", "Seattle Easter Swing" },
                    { 2, "Vancouver, BC", "Swingcouver" },
                    { 3, "Seattle, WA", "Sea To Sky" },
                    { 4, "Portland, OR", "Rose City Swing" },
                    { 5, "Burbank, CA", "US Open Swing Dance Championships" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "ID", "Director", "SeriesID", "Year" },
                values: new object[,]
                {
                    { 1, "Allen Ulbricht", 1, 2019 },
                    { 2, "John Kirkconnell", 2, 2019 },
                    { 3, "Mike Kielbasa", 3, 2019 },
                    { 4, "Babek Shakeri", 4, 2019 },
                    { 5, "Phil Dorroll", 5, 2019 }
                });

            migrationBuilder.InsertData(
                table: "EventCompetitions",
                columns: new[] { "ID", "CompType", "EventID", "Level" },
                values: new object[,]
                {
                    { 1, 0, 1, 1 },
                    { 2, 0, 1, 2 },
                    { 3, 0, 1, 3 },
                    { 4, 0, 1, 4 },
                    { 5, 0, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "EventCompetitionID", "CompetitorID", "Placement", "Role", "ScoreChief", "ScoreFive", "ScoreFour", "ScoreOne", "ScoreSix", "ScoreThree", "ScoreTwo" },
                values: new object[] { 1, 14007, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "EventCompetitionID", "CompetitorID", "Placement", "Role", "ScoreChief", "ScoreFive", "ScoreFour", "ScoreOne", "ScoreSix", "ScoreThree", "ScoreTwo" },
                values: new object[] { 3, 8717, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_EventCompetitions_EventID",
                table: "EventCompetitions",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SeriesID",
                table: "Events",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CompetitorID",
                table: "Results",
                column: "CompetitorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Competitors");

            migrationBuilder.DropTable(
                name: "EventCompetitions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
