using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _125_MusicLibraryBinusTask.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLikeToLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Songs",
                newName: "Likes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Songs",
                newName: "Like");
        }
    }
}
