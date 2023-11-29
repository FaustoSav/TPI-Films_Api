using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsAPI.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteMediaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Serie_MediaType",
                table: "Media");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FavoritesMedia",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FavoritesMedia");

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Serie_MediaType",
                table: "Media",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 1,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 2,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 3,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 4,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 5,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 6,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 7,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 8,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 9,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 10,
                column: "MediaType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 11,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 12,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 13,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 14,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 15,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 16,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 17,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 18,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 19,
                column: "Serie_MediaType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Media",
                keyColumn: "MediaId",
                keyValue: 20,
                column: "Serie_MediaType",
                value: 1);
        }
    }
}
