using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Example.SplitToTable.Migrations
{
    /// <inheritdoc />
    public partial class SplitToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Main_MainId",
                table: "Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Details_MainId",
                table: "Blog",
                column: "MainId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Details_MainId",
                table: "Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Main_MainId",
                table: "Blog",
                column: "MainId",
                principalTable: "Main",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
