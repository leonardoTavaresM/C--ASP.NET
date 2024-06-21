using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artists", new string[] { "Name", "Bio", "ProfilePhoto" }, new object[] {"Mastodon", "Mastodon is an American heavy metal band from Atlanta, Georgia.", "https://i.pinimg.com/originals/a9/1c/6d/a91c6d32e8956ef4d714a3255c164f2f.jpg" });

            migrationBuilder.InsertData("Artists", new string[] { "Name", "Bio", "ProfilePhoto" }, new object[] { "Foo Fighters", "Foo Fighters é uma banda de rock alternativo americana formada por Dave Grohl em 1995.", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });

            migrationBuilder.InsertData("Artists", new string[] { "Name", "Bio", "ProfilePhoto" }, new object[] { "Gojira", "Gojira is a French heavy metal band from Ondres.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnHyHI1BkvawdWVQhZLEq2WUFoGRHjqgj4_g&s" });
            
            migrationBuilder.InsertData("Artists", new string[] { "Name", "Bio", "ProfilePhoto" }, new object[] { "Queens of the Stone Age", "Queens of the Stone Age (commonly abbreviated as QOTSA) is an American rock band formed in 1996 in Seattle, Washington.", "https://i.pinimg.com/originals/69/17/93/6917933b952375e6678723ddb43d69bb.jpg" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artists");
        }
    }
}
