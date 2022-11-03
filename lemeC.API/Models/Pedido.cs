using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lemeC.API.Models
{
    public class Pedido
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("data")]
        public DateTime Instante { get; set; }
        public int IdClietePedido { get; set; }

        [ForeignKey(nameof(IdClietePedido))]
        [InverseProperty(nameof(Cliente.PedidoList))]
        public virtual Cliente ClientePedido { get; set; }
    }
}