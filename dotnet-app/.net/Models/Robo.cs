using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAIOCEAN.Models
{
    [Table("TB_MAIOCEAN_ROBO")]
    public class Robo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRobo { get; set; }

        [Required(ErrorMessage = "O status do robô é obrigatório")]
        public string StatusRobo { get; set; }

        [Required]
        [MaxLength(9)]
        public string NmrSerie { get; set; }

        public ICollection<Temperatura> ? Temperatura { get; set; }
    }
}
