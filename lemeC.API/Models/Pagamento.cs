using lemeC.API.Models.Enums;
using lemeC.API.Repositories.Interfaces;
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
        public int IdPedidoPagamento { get; set; }

        [ForeignKey(nameof(IdPedidoPagamento))]
        [InverseProperty(nameof(Pedido.PagamentoPagto))]
        public virtual Pedido? PedidoPagamento { get; set; }
    }
}