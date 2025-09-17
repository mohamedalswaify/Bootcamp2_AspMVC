using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp2_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class addCustomerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CustomerId",
                table: "CartItems",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Customers_CustomerId",
                table: "CartItems",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Customers_CustomerId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CustomerId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CartItems");
        }
    }
}
