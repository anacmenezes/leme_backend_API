using lemeC.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemeC.API.Models
{
    public class Pagamento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("estado")]
        public EstadoPagamento Estado { get; set; }
    }
}