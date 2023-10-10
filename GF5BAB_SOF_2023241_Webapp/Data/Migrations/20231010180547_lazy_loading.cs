using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GF5BAB_SOF_2023241_Webapp.Data.Migrations
{
    public partial class lazy_loading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EngineerId",
                table: "Parts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_EngineerId",
                table: "Parts",
                column: "EngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_AspNetUsers_EngineerId",
                table: "Parts",
                column: "EngineerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_AspNetUsers_EngineerId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_EngineerId",
                table: "Parts");

            migrationBuilder.AlterColumn<string>(
                name: "EngineerId",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
