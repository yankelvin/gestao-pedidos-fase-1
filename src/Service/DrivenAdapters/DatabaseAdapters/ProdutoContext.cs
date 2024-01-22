using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Produtos;

namespace Service.DrivenAdapters.DatabaseAdapters
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) { }
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<CategoriaProdutoEntity> Categorias { get; set; }
    }
}
