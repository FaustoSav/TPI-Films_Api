using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true),
                    MediaType = table.Column<int>(type: "INTEGER", nullable: true),
                    Serie_MediaType = table.Column<int>(type: "INTEGER", nullable: true),
                    Seasons = table.Column<int>(type: "INTEGER", nullable: true),
                    Episodes = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoritesMedia",
                columns: table => new
                {
                    FavoriteMediaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaType = table.Column<string>(type: "TEXT", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesMedia", x => x.FavoriteMediaId);
                    table.ForeignKey(
                        name: "FK_FavoritesMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritesMedia_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "MediaId", "Description", "Discriminator", "Duration", "Genre", "MediaType", "State", "Title" },
                values: new object[,]
                {
                    { 1, "Descripción de la película 1", "Movie", 101, "Action", 0, true, "Pelicula 1" },
                    { 2, "Descripción de la película 2", "Movie", 102, "Action", 0, true, "Pelicula 2" },
                    { 3, "Descripción de la película 3", "Movie", 103, "Action", 0, true, "Pelicula 3" },
                    { 4, "Descripción de la película 4", "Movie", 104, "Action", 0, true, "Pelicula 4" },
                    { 5, "Descripción de la película 5", "Movie", 105, "Action", 0, true, "Pelicula 5" },
                    { 6, "Descripción de la película 6", "Movie", 106, "Action", 0, true, "Pelicula 6" },
                    { 7, "Descripción de la película 7", "Movie", 107, "Action", 0, true, "Pelicula 7" },
                    { 8, "Descripción de la película 8", "Movie", 108, "Action", 0, true, "Pelicula 8" },
                    { 9, "Descripción de la película 9", "Movie", 109, "Action", 0, true, "Pelicula 9" },
                    { 10, "Descripción de la película 10", "Movie", 110, "Action", 0, true, "Pelicula 10" }
                });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "MediaId", "Description", "Discriminator", "Episodes", "Genre", "Serie_MediaType", "Seasons", "State", "Title" },
                values: new object[,]
                {
                    { 11, "Descripción de la serie 1", "Serie", 4, "Comedy", 1, 2, true, "Serie 1" },
                    { 12, "Descripción de la serie 2", "Serie", 5, "Comedy", 1, 3, true, "Serie 2" },
                    { 13, "Descripción de la serie 3", "Serie", 6, "Comedy", 1, 4, true, "Serie 3" },
                    { 14, "Descripción de la serie 4", "Serie", 7, "Comedy", 1, 5, true, "Serie 4" },
                    { 15, "Descripción de la serie 5", "Serie", 8, "Comedy", 1, 6, true, "Serie 5" },
                    { 16, "Descripción de la serie 6", "Serie", 9, "Comedy", 1, 7, true, "Serie 6" },
                    { 17, "Descripción de la serie 7", "Serie", 10, "Comedy", 1, 8, true, "Serie 7" },
                    { 18, "Descripción de la serie 8", "Serie", 11, "Comedy", 1, 9, true, "Serie 8" },
                    { 19, "Descripción de la serie 9", "Serie", 12, "Comedy", 1, 10, true, "Serie 9" },
                    { 20, "Descripción de la serie 10", "Serie", 13, "Comedy", 1, 11, true, "Serie 10" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "State", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "fariasfranco@gmail.com", "Farias", "Franco", "123456", true, "FrancoFarias", "Admin" },
                    { 2, "savoyafausto@gmail.com", "Savoya", "Fausto", "123456", true, "FaustoSav", "Admin" },
                    { 3, "regular@gmail.com", "Garcia", "Pedro", "123456", true, "regular", "RegularUser" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesMedia_MediaId",
                table: "FavoritesMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesMedia_UserId",
                table: "FavoritesMedia",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritesMedia");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
