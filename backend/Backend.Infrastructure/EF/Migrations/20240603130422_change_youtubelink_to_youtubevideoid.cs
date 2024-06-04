using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class change_youtubelink_to_youtubevideoid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YoutubeUrl",
                table: "Lessons",
                newName: "YoutubeVideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YoutubeVideoId",
                table: "Lessons",
                newName: "YoutubeUrl");
        }
    }
}
