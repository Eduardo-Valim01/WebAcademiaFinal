using Microsoft.EntityFrameworkCore;
using WebAcademiaFinal.Models;
using WebAcademiaProfessor.Models;

namespace WebAcademiaFinal.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Aula> Aulas { get; set; }

    }
}
