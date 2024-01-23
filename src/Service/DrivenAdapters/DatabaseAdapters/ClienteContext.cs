using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DataBaseAdapters.Entities.Clientes;

namespace Service.DrivenAdapters.DatabaseAdapters
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }
        public DbSet<ClienteEntity> Clientes { get; set; }
    }
}
