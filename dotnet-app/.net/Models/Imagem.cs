using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAIOCEAN.Models
{
    [Table("TB_MAIOCEAN_IMAGEM")]
    public class Imagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdImagem { get; set; }

        [Column("DS_CAMINHO", TypeName = "varchar(15)")]
        public string CaminhoImagem { get; set;}

        [Required]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "A profundidade em que a imagem será capturada é obrigatória")]
        public double Profundidade { get; set; }

        [Required(ErrorMessage = "A latitude é obrigatória")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "A longitude é obrigatória")]
        public double Longitude { get; set; }


        public int IdRobo { get; set; }
        public Robo ? Robo {  get; set; }

        public int IdRegiao { get; set; }
        public Regiao ? Regiao {  get; set; }

    }
}
