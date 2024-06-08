 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAIOCEAN.Models
{
    [Table("TB_MAIOCEAN_REGIAO")]
    public class Regiao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegiao { get; set; }

        [Required(ErrorMessage = "O nome da região é obrigatório")]
        public string NomeRegiao { get; set; }

        [Required]
        public double TempMedia {  get; set; }

        [Required(ErrorMessage = "O status da região é obrigatório")]
        public string StatusRegiao { get; set;}


        public int IdRobo {  get; set; }
        public Robo ? Robo {  get; set; }

        public ICollection<Especie> ? Especie { get; set; }
    }
}
