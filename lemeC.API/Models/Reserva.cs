using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemeC.API.Models
{
    public class Reserva
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("origem")]
        public string? Origem { get; set; }
    }
}