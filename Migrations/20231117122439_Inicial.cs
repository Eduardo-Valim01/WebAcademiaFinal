using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAcademiaFinal.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    especializacao = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    sexo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    endereco = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nometreino = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    descricaotreino = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    duracao = table.Column<int>(type: "int", nullable: false),
                    dificuldade = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    datanasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ojetivo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    peso = table.Column<float>(type: "real", nullable: false),
                    treinoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alunos_Treinos_treinoID",
                        column: x => x.treinoID,
                        principalTable: "Treinos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoID = table.Column<int>(type: "int", nullable: false),
                    professorID = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Aulas_Alunos_alunoID",
                        column: x => x.alunoID,
                        principalTable: "Alunos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aulas_Professores_professorID",
                        column: x => x.professorID,
                        principalTable: "Professores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_treinoID",
                table: "Alunos",
                column: "treinoID");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_alunoID",
                table: "Aulas",
                column: "alunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_professorID",
                table: "Aulas",
                column: "professorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Treinos");
        }
    }
}
