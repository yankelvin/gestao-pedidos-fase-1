using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Pedidos;

namespace Service.DrivenAdapters.DatabaseAdapters;

public class PedidoContext : DbContext
{
    public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }
    public DbSet<PedidoEntity> Pedidos { get; set; }
}