using Microsoft.EntityFrameworkCore.Migrations;

namespace Wema.CampusRunz.Data.Migrations
{
    public partial class UpdatedHotelOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelOrders_OrderCategories_OrderCategoriesId",
                table: "HotelOrders");

            migrationBuilder.DropIndex(
                name: "IX_HotelOrders_OrderCategoriesId",
                table: "HotelOrders");

            migrationBuilder.DropColumn(
                name: "OrderCategoriesId",
                table: "HotelOrders");

            migrationBuilder.AddColumn<int>(
                name: "HotelOrderId",
                table: "OrderCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderCategories_HotelOrderId",
                table: "OrderCategories",
                column: "HotelOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCategories_HotelOrders_HotelOrderId",
                table: "OrderCategories",
                column: "HotelOrderId",
                principalTable: "HotelOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCategories_HotelOrders_HotelOrderId",
                table: "OrderCategories");

            migrationBuilder.DropIndex(
                name: "IX_OrderCategories_HotelOrderId",
                table: "OrderCategories");

            migrationBuilder.DropColumn(
                name: "HotelOrderId",
                table: "OrderCategories");

            migrationBuilder.AddColumn<int>(
                name: "OrderCategoriesId",
                table: "HotelOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrders_OrderCategoriesId",
                table: "HotelOrders",
                column: "OrderCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelOrders_OrderCategories_OrderCategoriesId",
                table: "HotelOrders",
                column: "OrderCategoriesId",
                principalTable: "OrderCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
