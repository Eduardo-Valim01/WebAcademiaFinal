using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAcademiaFinal.Models
{
    public enum Dificuldade { Facil, Normal, Dificil }

    [Table("Treinos")]
    public class Treino
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Nome do treino é obrigatório...")]
        [StringLength(25)]
        [Display(Name = "Nome do treino")]
        public string nometreino { get; set; }

        [Required(ErrorMessage = "Campo Descrição do treino é obrigatório...")]
        [StringLength(25)]
        [Display(Name = "(Séries, e Repetiçoes)")]
        public string descricaotreino { get; set; }

        [Required(ErrorMessage = "Duração do Treino é Obrigatório...")]
        [Display(Name = "Duração do Treino")]
        public int duracao { get; set; }

        [Required(ErrorMessage = "Campo Dificuldade é obrigatório...")]
        [Display(Name = "Dificuldade")]
        public Dificuldade dificuldade { get; set; }


    }
}
