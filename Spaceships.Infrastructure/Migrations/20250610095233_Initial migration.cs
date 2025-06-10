using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spaceships.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spaceships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceshipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportType = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceships", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Spaceships",
                columns: new[] { "Id", "CompanyName", "Description", "ImageUrl", "SpaceshipName", "TransportType" },
                values: new object[,]
                {
                    { 1, "SpaceX", "SpaceX's uncrewed spacecraft used to deliver supplies to the ISS.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/SpaceX_CRS-20_Dragon.jpg/640px-SpaceX_CRS-20_Dragon.jpg", "Dragon Cargo", 1 },
                    { 2, "SpaceX", "SpaceX's reusable capsule for transporting astronauts to the ISS.", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9b/Crew_Dragon_Demo-2_%28NHQ202005300036%29.jpg/640px-Crew_Dragon_Demo-2_%28NHQ202005300036%29.jpg", "Dragon Crew", 0 },
                    { 3, "SpaceX", "Next-gen fully reusable spacecraft for Mars missions, currently under development.", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Starship_SN9_launch.jpg/640px-Starship_SN9_launch.jpg", "Starship", 1 },
                    { 4, "NASA / ESA", "NASA’s spacecraft for deep-space crewed missions beyond the Moon.", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Orion_Capsule_%28Space_Expo%29.jpg/640px-Orion_Capsule_%28Space_Expo%29.jpg", "Orion", 0 },
                    { 5, "Roscosmos", "Russian spacecraft used for crew transport since the 1960s.", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Soyuz_TMA-16_spacecraft.jpg/640px-Soyuz_TMA-16_spacecraft.jpg", "Soyuz", 0 },
                    { 6, "Roscosmos", "Uncrewed cargo spacecraft used to resupply the ISS.", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/Progress_M1-10.jpg/640px-Progress_M1-10.jpg", "Progress", 1 },
                    { 7, "Sierra Space", "Spaceplane being developed for cargo delivery to the ISS.", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Dream_Chaser_mission_illustration.jpg/640px-Dream_Chaser_mission_illustration.jpg", "Dream Chaser", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spaceships");
        }
    }
}
