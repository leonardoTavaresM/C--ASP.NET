using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class addingSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musics", new string[] { "Name", "ReleaseYear" }, new object[] { "Teardrinker", 2021 });
            migrationBuilder.InsertData("Musics", new string[] { "Name", "ReleaseYear" }, new object[] { "Sultan's Curse", 2017 });
            migrationBuilder.InsertData("Musics", new string[] { "Name", "ReleaseYear" }, new object[] { "Everlong", 1997 });
            migrationBuilder.InsertData("Musics", new string[] { "Name", "ReleaseYear" }, new object[] { "Make It Wit Chu", 2007 });
            migrationBuilder.InsertData("Musics", new string[] { "Name", "ReleaseYear" }, new object[] { "Born in Winter", 2012 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musics");
        }
    }
}
