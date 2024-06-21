using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class FillingRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Musics SET ArtistId = 1 WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Musics SET ArtistId = 1 WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Musics SET ArtistId = 2 WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Musics SET ArtistId = 4 WHERE Id = 4");
            migrationBuilder.Sql("UPDATE Musics SET ArtistId = 3 WHERE Id = 5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
