using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShopcartItems");

            migrationBuilder.CreateIndex(
                name: "IX_Shopcarts_UserId",
                table: "Shopcarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shopcarts_users_UserId",
                table: "Shopcarts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shopcarts_users_UserId",
                table: "Shopcarts");

            migrationBuilder.DropIndex(
                name: "IX_Shopcarts_UserId",
                table: "Shopcarts");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Shopcarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Shopcarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shopcarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Shopcarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Shopcarts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ShopcartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopcartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShopcartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "ShopcartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShopcartItems",
                type: "datetime2",
                nullable: true);
        }
    }
}
