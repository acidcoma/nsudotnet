using Microsoft.EntityFrameworkCore.Migrations;

namespace lab4.Migrations
{
    public partial class AddPatronymic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Patronimic",
                table: "Workers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Patronimic",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Workers_WorkerId",
                table: "Projects",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
