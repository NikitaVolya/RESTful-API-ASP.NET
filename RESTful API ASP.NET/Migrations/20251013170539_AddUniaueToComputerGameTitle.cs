using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTful_API_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddUniaueToComputerGameTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ComputerGames_Title",
                table: "ComputerGames",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ComputerGames_Title",
                table: "ComputerGames");
        }
    }
}
