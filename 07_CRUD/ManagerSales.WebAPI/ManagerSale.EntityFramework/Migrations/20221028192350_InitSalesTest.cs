using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerSale.EntityFramework.Migrations
{
    public partial class InitSalesTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_Product_ProductId",
                table: "SaleProducts",
                column: "ProductId",
                principalTable: "ProductsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleProducts_Product_ProductId",
                table: "SaleProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProducts_ProductsType_ProductId",
                table: "SaleProducts",
                column: "ProductId",
                principalTable: "ProductsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
