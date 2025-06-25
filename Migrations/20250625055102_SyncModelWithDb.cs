using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPaliNumb.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelWithDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Palindromos",
                table: "Palindromos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Numeros",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Palindromos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Palindromos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palindromos",
                table: "Palindromos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Palindromos",
                table: "Palindromos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Palindromos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Numeros",
                newName: "Valor");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Palindromos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palindromos",
                table: "Palindromos",
                column: "Texto");
        }
    }
}
