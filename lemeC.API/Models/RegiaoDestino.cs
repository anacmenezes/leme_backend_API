using lemeC.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemeC.API.Models
{
    public class RegiaoDestino
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(255)]
        public string? Nome { get; set; }
        [Column("tipo")]
        public TipoRegiao Tipo { get; set; }

        [InverseProperty("RegiaoCidade")]
        public virtual ICollection<CidadeDestino>? DestinoList { get; set; }
    }
}