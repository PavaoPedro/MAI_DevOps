using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAIOCEAN.Models
{
    [Table("TB_MAIOCEAN_TEMPERATURA")]
    public class Temperatura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTemperatura { get; set; }

        [Required(ErrorMessage = "O valor da temperatura registrada é obrigatório")]
        public double ValorTemperatura { get; set; }

        [Required]
        public DateTime DataColeta { get; set; }

        [Required(ErrorMessage = "A profundidade onde a temperatura foi captada é obrigatória")]
        public double ProfundTemperatura { get; set; }

        [Required(ErrorMessage = "A latitude onde a temperatura foi captada é obrigatória")]
        public double LatitudeTemp {  get; set; }

        [Required(ErrorMessage = "A longitude onde a temperatura foi captada é obrigatória")]
        public double LongitudeTemp { get; set;}

        public int IdRegiao { get; set; }
        public Regiao ? Regiao { get; set; }

        public ICollection<Robo> ? Robo { get; set; }
    }
}
