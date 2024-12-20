using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Pessoas_pessoaid",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_pessoaid",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "pessoaid",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Tasks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Tasks",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "categoria",
                table: "Tasks",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Pessoas",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Pessoas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Pessoas",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pessoas",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tasks",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Tasks",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Tasks",
                newName: "categoria");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tasks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Pessoas",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pessoas",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Pessoas",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pessoas",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "pessoaid",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_pessoaid",
                table: "Tasks",
                column: "pessoaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Pessoas_pessoaid",
                table: "Tasks",
                column: "pessoaid",
                principalTable: "Pessoas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
