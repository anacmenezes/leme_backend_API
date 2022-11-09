using Microsoft.EntityFrameworkCore;
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
        [Column("idCliente")]
        public int IdClietePedido { get; set; }

        [ForeignKey(nameof(IdClietePedido))]
        [InverseProperty(nameof(Cliente.PedidoList))]
        public virtual Cliente? ClientePedido { get; set; }

        [InverseProperty("PedidoReserva")]
        public virtual ICollection<Reserva>? ReservaList { get; set; }

        [InverseProperty("PedidoPagamento")]
        public virtual DbSet<Pagamento>? PagamentoPagto { get; set; }
    }
}