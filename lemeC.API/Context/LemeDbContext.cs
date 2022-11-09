using lemeC.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lemeC.API.Context
{
    public class LemeDbContext : DbContext
    {
#pragma warning disable CS8618
        public LemeDbContext()
#pragma warning restore CS8618
        {
        }

#pragma warning disable CS8618
        public LemeDbContext(DbContextOptions<LemeDbContext> options)
#pragma warning restore CS8618
        : base(options)
        {
        }

        public virtual DbSet<CidadeDestino> Dest { get; set; }
        public virtual DbSet<Cliente> User { get; set; }
        public virtual DbSet<Pedido> Itens { get; set; }
        public object CidadeDestino { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.Entity<CidadeDestino>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
                entity.Property(e => e.Duracao).IsUnicode(false);
                entity.Property(e => e.Preco).IsUnicode(false);

                entity.HasOne(d => d.RegiaoCidade)
                .WithMany(p => p.DestinoList)
                .HasForeignKey(d => d.IdRegiaoCidade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Regiao_Cidade");
            });

            modelBuilder.Entity<RegiaoDestino>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
                entity.Property(e => e.Nome).IsUnicode(false);
                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.Origem).IsUnicode(false);

                entity.HasOne(d => d.CidadeReserva)
                .WithMany(p => p.ReservaList)
                .HasForeignKey(d => d.IdCidadeReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cidade_Reserva");

                entity.HasOne(d => d.PedidoReserva)
                .WithMany(p => p.ReservaList)
                .HasForeignKey(d => d.IdPedidoReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Reserva");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
                entity.Property(e => e.Email).IsUnicode(false);
                entity.Property(e => e.Senha).IsUnicode(false);
                entity.Property(e => e.Cpf).IsUnicode(false);
                entity.Property(e => e.Telefone).IsUnicode(false);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Instante).IsUnicode(false);

                entity.HasOne(d => d.ClientePedido)
                .WithMany(p => p.PedidoList)
                .HasForeignKey(d => d.IdClietePedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Pedido");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Logradouro).IsUnicode(false);
                entity.Property(e => e.Numero).IsUnicode(false);
                entity.Property(e => e.Complemento).IsUnicode(false);
                entity.Property(e => e.Bairro).IsUnicode(false);
                entity.Property(e => e.Estado).IsUnicode(false);
                entity.Property(e => e.Cidade).IsUnicode(false);
                entity.Property(e => e.Cep).IsUnicode(false);

                 entity.HasOne(d => d.ClienteEndereco)
                .WithMany(p => p.EnderecoList)
                .HasForeignKey(d => d.IdClieteEndereco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Endereco");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.Property(e => e.Estado).IsUnicode(false);

                entity.HasOne(d => d.PedidoPagamento)
                .WithMany(p => p.PagamentoPagto)
                .HasForeignKey(d => d.IdPedidoPagamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Pagamento");
            });
        }
    }
}
