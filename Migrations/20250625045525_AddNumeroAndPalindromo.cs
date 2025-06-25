using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPaliNumb.Migrations
{
    /// <inheritdoc />
    public partial class AddNumeroAndPalindromo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Numeros",
                columns: table => new
                {
                    Valor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsPar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numeros", x => x.Valor);
                });

            migrationBuilder.CreateTable(
                name: "Palindromos",
                columns: table => new
                {
                    Texto = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EsPalindromo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palindromos", x => x.Texto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numeros");

            migrationBuilder.DropTable(
                name: "Palindromos");
        }
    }
}
