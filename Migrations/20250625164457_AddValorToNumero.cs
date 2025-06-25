using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPaliNumb.Migrations
{
    /// <inheritdoc />
    public partial class AddValorToNumero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "Numeros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Numeros");
        }
    }
}
