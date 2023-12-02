using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemove",
                table: "categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "productsImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productsImages_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productsImages_ProductId",
                table: "productsImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productsImages");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "products");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "products");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "IsRemove",
                table: "categories");
        }
    }
}
