using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemeC.API.Models
{
    public class CidadeDestino
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(255)]
        public string? Nome { get; set; }
        [Required]
        [Column("duracao")]
        public string? Duracao { get; set; }
        [Required]
        [Column("preco")]
        public string? Preco { get; set; }
    }
}