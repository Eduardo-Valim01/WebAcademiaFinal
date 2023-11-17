using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAcademiaFinal.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(14)]
        [Required(ErrorMessage = "Campo CPF é obrigatório...")]
        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório...")]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Idade")]
        public int idade { get; set; }

        [StringLength(25)]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo Cidade é obrigatório...")]
        [StringLength(25)]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        [Display(Name = "Data Nascimento")]
        public DateTime datanasc { get; set; }

        [Display(Name = "Objetivo do Treino")]
        [StringLength(25)]
        public string ojetivo { get; set; }

        [Required(ErrorMessage = "Campo Peso é obrigatório...")]
        [Display(Name = "Peso")]
        public float peso { get; set; }

        [Display(Name = "Treino")]
        public int treinoID { get; set; }
        [ForeignKey("treinoID")]
        public Treino treino { get; set; }

    }
}