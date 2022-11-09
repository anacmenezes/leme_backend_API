using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemeC.API.Models
{
    public class Endereco
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("logradouro")]
        [StringLength(255)]
        public string? Logradouro { get; set; }
        [Required]
        [Column("numero")]
        [StringLength(6)]
        public string? Numero { get; set; }
        [Column("complemento")]
        [StringLength(255)]
        public string? Complemento { get; set; }
        [Required]
        [Column("bairro")]
        [StringLength(255)]
        public int Bairro { get; set; }
        [Required]
        [Column("estado")]
        [StringLength(200)]
        public string? Estado { get; set; }
        [Required]
        [Column("cidade")]
        [StringLength(200)]
        public string? Cidade { get; set; }
        [Required]
        [Column("cep")]
        [StringLength(8)]
        public string? Cep { get; set; }
        public int IdClieteEndereco { get; set; }

        [ForeignKey(nameof(IdClieteEndereco))]
        [InverseProperty(nameof(Cliente.EnderecoList))]
        public virtual Cliente? ClienteEndereco { get; set; }
    }
}