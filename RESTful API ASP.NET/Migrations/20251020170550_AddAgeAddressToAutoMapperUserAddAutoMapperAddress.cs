using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTful_API_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddAgeAddressToAutoMapperUserAddAutoMapperAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoMapperAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMapperAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoMapperUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMapperUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoMapperUsers_AutoMapperAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AutoMapperAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoMapperUsers_AddressId",
                table: "AutoMapperUsers",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoMapperUsers");

            migrationBuilder.DropTable(
                name: "AutoMapperAddresses");
        }
    }
}
