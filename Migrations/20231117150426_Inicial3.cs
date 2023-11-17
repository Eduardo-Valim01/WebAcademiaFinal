using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAcademiaFinal.Migrations
{
    /// <inheritdoc />
    public partial class Inicial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Professores");

            migrationBuilder.AddColumn<int>(
                name: "situacao",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "situacao",
                table: "Professores");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Professores",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);
        }
    }
}
