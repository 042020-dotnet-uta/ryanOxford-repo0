using Microsoft.EntityFrameworkCore.Migrations;

namespace Project0.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Inventory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Inventory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationID",
                table: "Inventory",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductID",
                table: "Inventory",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Locations_LocationID",
                table: "Inventory",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductID",
                table: "Inventory",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Locations_LocationID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProductID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_LocationID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ProductID",
                table: "Inventory");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Inventory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Inventory",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
