﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp2_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class uid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "uid",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uid",
                table: "Categories");
        }
    }
}
