using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DataBaseAdapters.Entities.ItensPedido;

namespace Service.DrivenAdapters.DatabaseAdapters;

public class ItensPedidoContext : DbContext
{
    public ItensPedidoContext(DbContextOptions<ItensPedidoContext> options) : base(options) { }
    public DbSet<ItensPedidoEntity> ItensPedido { get; set; }
}