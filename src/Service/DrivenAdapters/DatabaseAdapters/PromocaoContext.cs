using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Promocoes;

namespace Service.DrivenAdapters.DatabaseAdapters
{
    public class PromocaoContext : DbContext
    {
        public PromocaoContext(DbContextOptions<PromocaoContext> options) : base(options) { }

        public DbSet<PromocaoEntity> Promocoes { get; set; }
        public DbSet<ItemPromocaoEntity> ItensPromocoes { get; set; }
        public DbSet<HistoricoUsoPromocaoEntity> HistoricosUsoPromocoes { get; set; }
    }
}
