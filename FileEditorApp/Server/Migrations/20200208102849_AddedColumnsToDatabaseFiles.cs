using Microsoft.EntityFrameworkCore.Migrations;

namespace FileEditorApp.Server.Migrations
{
    public partial class AddedColumnsToDatabaseFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseFile_Users_UserId",
                table: "DatabaseFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatabaseFile",
                table: "DatabaseFile");

            migrationBuilder.RenameTable(
                name: "DatabaseFile",
                newName: "DatabaseFiles");

            migrationBuilder.RenameIndex(
                name: "IX_DatabaseFile_UserId",
                table: "DatabaseFiles",
                newName: "IX_DatabaseFiles_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DatabaseFiles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DatabaseFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "DatabaseFiles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatabaseFiles",
                table: "DatabaseFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseFiles_Users_UserId",
                table: "DatabaseFiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatabaseFiles_Users_UserId",
                table: "DatabaseFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatabaseFiles",
                table: "DatabaseFiles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DatabaseFiles");

            migrationBuilder.DropColumn(
                name: "Uri",
                table: "DatabaseFiles");

            migrationBuilder.RenameTable(
                name: "DatabaseFiles",
                newName: "DatabaseFile");

            migrationBuilder.RenameIndex(
                name: "IX_DatabaseFiles_UserId",
                table: "DatabaseFile",
                newName: "IX_DatabaseFile_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DatabaseFile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatabaseFile",
                table: "DatabaseFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatabaseFile_Users_UserId",
                table: "DatabaseFile",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
