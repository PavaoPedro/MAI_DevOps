using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAIOCEAN.Models
{
    [Table("TB_MAIOCEAN_ESPECIES")]
    public class Especie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspecie { get; set; }

        [Required(ErrorMessage = "O nome da espécie é obrigatório")]
        public string NomeEspecie { get; set; }

        [Column("Ds_Especie", TypeName = "varchar(155)")]
        public string DescricaoEspecie { get; set;}

        [Required(ErrorMessage = "O status da espécie é obrigatório")]
        public string StatusEspecie { get; set; }

        public ICollection<Regiao> ? Regiao { get; set; }
    }
}
