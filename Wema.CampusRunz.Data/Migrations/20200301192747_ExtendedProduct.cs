using Microsoft.EntityFrameworkCore.Migrations;

namespace Wema.CampusRunz.Data.Migrations
{
    public partial class ExtendedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductPhotos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageString",
                table: "ProductPhotos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhotos_Products_ProductId",
                table: "ProductPhotos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhotos_Products_ProductId",
                table: "ProductPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos");

            migrationBuilder.DropColumn(
                name: "ImageString",
                table: "ProductPhotos");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "ProductPhotos",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
