using Microsoft.EntityFrameworkCore.Migrations;

namespace Arena_Data.Migrations
{
    public partial class UserRenameInUposlenik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uposlenici_AspNetUsers_NalogId",
                table: "Uposlenici");

            migrationBuilder.DropIndex(
                name: "IX_Uposlenici_NalogId",
                table: "Uposlenici");

            migrationBuilder.DropColumn(
                name: "NalogId",
                table: "Uposlenici");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Uposlenici",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_UserId",
                table: "Uposlenici",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uposlenici_AspNetUsers_UserId",
                table: "Uposlenici",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uposlenici_AspNetUsers_UserId",
                table: "Uposlenici");

            migrationBuilder.DropIndex(
                name: "IX_Uposlenici_UserId",
                table: "Uposlenici");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Uposlenici",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NalogId",
                table: "Uposlenici",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_NalogId",
                table: "Uposlenici",
                column: "NalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uposlenici_AspNetUsers_NalogId",
                table: "Uposlenici",
                column: "NalogId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
