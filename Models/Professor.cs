using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAcademiaProfessor.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório...")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Especialização é obrigatório...")]
        [StringLength(25)]
        [Display(Name = "Especialização do Professor")]
        public string especializacao { get; set; }

        [Display(Name = "Idade")]
        public int idade { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(10)]
        public string sexo { get; set; }

        [StringLength(25)]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Campo Telefone é obrigatório...")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

    }
}