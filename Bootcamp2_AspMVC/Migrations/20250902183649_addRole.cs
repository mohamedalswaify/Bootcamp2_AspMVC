﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp2_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserRoleId",
                table: "Employees",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserRoles_UserRoleId",
                table: "Employees",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserRoles_UserRoleId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserRoleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Employees");
        }
    }
}
