using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Pedidos;
using Service.DrivenAdapters.DatabaseAdapters.MapContext;

namespace Service.DrivenAdapters.DatabaseAdapters;

public class PedidoContext : DbContext
{
    public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }
    public DbSet<PedidoEntity> Pedidos { get; set; }
    public DbSet<ItensPedidoEntity> ItensPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        ConfigureMap.Config(modelBuilder);
        

    }
}