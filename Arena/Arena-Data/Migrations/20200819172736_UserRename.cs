using Microsoft.EntityFrameworkCore.Migrations;

namespace Arena_Data.Migrations
{
    public partial class UserRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administratori_AspNetUsers_NalogId",
                table: "Administratori");

            migrationBuilder.DropForeignKey(
                name: "FK_Klijenti_AspNetUsers_NalogId",
                table: "Klijenti");

            migrationBuilder.DropIndex(
                name: "IX_Klijenti_NalogId",
                table: "Klijenti");

            migrationBuilder.DropIndex(
                name: "IX_Administratori_NalogId",
                table: "Administratori");

            migrationBuilder.DropColumn(
                name: "NalogId",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "NalogId",
                table: "Administratori");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Klijenti",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Administratori",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_UserId",
                table: "Klijenti",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Administratori_UserId",
                table: "Administratori",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administratori_AspNetUsers_UserId",
                table: "Administratori",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klijenti_AspNetUsers_UserId",
                table: "Klijenti",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administratori_AspNetUsers_UserId",
                table: "Administratori");

            migrationBuilder.DropForeignKey(
                name: "FK_Klijenti_AspNetUsers_UserId",
                table: "Klijenti");

            migrationBuilder.DropIndex(
                name: "IX_Klijenti_UserId",
                table: "Klijenti");

            migrationBuilder.DropIndex(
                name: "IX_Administratori_UserId",
                table: "Administratori");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NalogId",
                table: "Klijenti",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Administratori",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NalogId",
                table: "Administratori",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klijenti_NalogId",
                table: "Klijenti",
                column: "NalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Administratori_NalogId",
                table: "Administratori",
                column: "NalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administratori_AspNetUsers_NalogId",
                table: "Administratori",
                column: "NalogId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klijenti_AspNetUsers_NalogId",
                table: "Klijenti",
                column: "NalogId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
