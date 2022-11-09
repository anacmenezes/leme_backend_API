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
        public int IdCidadeReserva { get; set; }
        public int IdPedidoReserva { get; set; }

        [ForeignKey(nameof(IdCidadeReserva))]
        [InverseProperty(nameof(CidadeDestino.ReservaList))]
        public virtual CidadeDestino? CidadeReserva { get; set; }

        [ForeignKey(nameof(IdPedidoReserva))]
        [InverseProperty(nameof(Pedido.ReservaList))]
        public virtual Pedido? PedidoReserva { get; set; }
    }
}