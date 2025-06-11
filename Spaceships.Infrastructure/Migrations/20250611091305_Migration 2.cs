using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spaceships.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/dragon-cargo.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/dragon-crew.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/starship.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/orion.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/soyuz.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "/Images/progress.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "/Images/dream-chaser.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/SpaceX_CRS-20_Dragon.jpg/640px-SpaceX_CRS-20_Dragon.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9b/Crew_Dragon_Demo-2_%28NHQ202005300036%29.jpg/640px-Crew_Dragon_Demo-2_%28NHQ202005300036%29.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Starship_SN9_launch.jpg/640px-Starship_SN9_launch.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Orion_Capsule_%28Space_Expo%29.jpg/640px-Orion_Capsule_%28Space_Expo%29.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Soyuz_TMA-16_spacecraft.jpg/640px-Soyuz_TMA-16_spacecraft.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/Progress_M1-10.jpg/640px-Progress_M1-10.jpg");

            migrationBuilder.UpdateData(
                table: "Spaceships",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3e/Dream_Chaser_mission_illustration.jpg/640px-Dream_Chaser_mission_illustration.jpg");
        }
    }
}
