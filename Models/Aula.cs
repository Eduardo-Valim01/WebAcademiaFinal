using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAcademiaProfessor.Models;

namespace WebAcademiaFinal.Models
{
    public class Aula
    {

        [Key]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        public int alunoID { get; set; }
        [ForeignKey("alunoID")]
        [Display(Name = "Aluno: ")]
        public Aluno aluno { get; set; }


        public int professorID { get; set; }
        [ForeignKey("professorID")]
        [Display(Name = "Professor: ")]
        public Professor professor { get; set; }


        [Required(ErrorMessage = "campo data é obrigatório")]
        [Display(Name = "Data: ")]
        public DateTime data { get; set; }

    }
}