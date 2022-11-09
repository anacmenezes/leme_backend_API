using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemeC.API.Models
{
    public class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(255)]
        public string? Nome { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string? Email { get; set; }
        [Required]
        [Column("senha")]
        [StringLength(8)]
        public string? Senha { get; set; }
        [Required]
        [Column("cpf")]
        [StringLength(14)]
        public string? Cpf { get; set; }
        [Column("telefone")]
        public string? Telefone { get; set; }

        [InverseProperty("ClienteEndereco")]
        public virtual ICollection<Endereco>? EnderecoList { get; set; }

        [InverseProperty("ClientePedido")]
        public virtual ICollection<Pedido>? PedidoList { get; set; }
    }
}