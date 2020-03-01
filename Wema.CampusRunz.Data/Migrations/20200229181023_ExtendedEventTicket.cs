using Microsoft.EntityFrameworkCore.Migrations;

namespace Wema.CampusRunz.Data.Migrations
{
    public partial class ExtendedEventTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventTicketOrders_OrderCategories_OrderCategoriesId",
                table: "EventTicketOrders");

            migrationBuilder.DropIndex(
                name: "IX_EventTicketOrders_OrderCategoriesId",
                table: "EventTicketOrders");

            migrationBuilder.DropColumn(
                name: "OrderCategoriesId",
                table: "EventTicketOrders");

            migrationBuilder.AddColumn<int>(
                name: "EventTicketOrderId",
                table: "OrderCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderCategories_EventTicketOrderId",
                table: "OrderCategories",
                column: "EventTicketOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCategories_EventTicketOrders_EventTicketOrderId",
                table: "OrderCategories",
                column: "EventTicketOrderId",
                principalTable: "EventTicketOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCategories_EventTicketOrders_EventTicketOrderId",
                table: "OrderCategories");

            migrationBuilder.DropIndex(
                name: "IX_OrderCategories_EventTicketOrderId",
                table: "OrderCategories");

            migrationBuilder.DropColumn(
                name: "EventTicketOrderId",
                table: "OrderCategories");

            migrationBuilder.AddColumn<int>(
                name: "OrderCategoriesId",
                table: "EventTicketOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketOrders_OrderCategoriesId",
                table: "EventTicketOrders",
                column: "OrderCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTicketOrders_OrderCategories_OrderCategoriesId",
                table: "EventTicketOrders",
                column: "OrderCategoriesId",
                principalTable: "OrderCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
