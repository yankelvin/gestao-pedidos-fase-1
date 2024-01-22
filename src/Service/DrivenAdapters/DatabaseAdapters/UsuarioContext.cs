using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Usuarios;

namespace Service.DrivenAdapters.DatabaseAdapters
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
    }
}
