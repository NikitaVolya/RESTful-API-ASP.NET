using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTful_API_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAndOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoMapperOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMapperOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_AutoMapperOrders_AutoMapperUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AutoMapperUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoMapperOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMapperOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoMapperOrderItems_AutoMapperOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "AutoMapperOrders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoMapperOrderItems_OrderId",
                table: "AutoMapperOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMapperOrders_UserId",
                table: "AutoMapperOrders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoMapperOrderItems");

            migrationBuilder.DropTable(
                name: "AutoMapperOrders");
        }
    }
}
