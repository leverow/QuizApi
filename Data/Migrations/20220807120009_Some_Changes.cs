using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApi.Data.Migrations
{
    public partial class Some_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameHash",
                table: "Topics",
                type: "nvarchar(64)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topics",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Topics",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_NameHash",
                table: "Topics",
                column: "NameHash",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_NameHash",
                table: "Topics");

            migrationBuilder.AlterColumn<string>(
                name: "NameHash",
                table: "Topics",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Topics",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Topics",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");
        }
    }
}
