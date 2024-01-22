using Domain.Ports.Driven.Produtos;
using Domain.Ports.Driven.Promocoes;
using Domain.Ports.Driven.Usuarios;
using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters;
using Service.DrivenAdapters.DataBaseAdapters.Migrations;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Promocoes;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Produtos;
using Service.DrivenAdapters.DatabaseAdapters.Adapters.Usuarios;

namespace Service.DrivenAdapters.DataBaseAdapters.Configuration
{
    public static class DatabaseAdaptersConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string databaseConnection)
        {
            services.AddDbContext<PromocaoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<ProdutoContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddDbContext<UsuarioContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
            services.AddHostedService<MigratorHostedService>();

            services.AddTransient<IPromocaoPersistencePort, PromocaoPersistenceAdapter>();
            services.AddTransient<IItemPromocaoPersistencePort, ItemPromocaoPersistenceAdapter>();
            services.AddTransient<IHistoricoUsoPromocaoPersistencePort, HistoricoUsoPromocaoPersistenceAdapter>();
            
            services.AddTransient<IProdutoPersistencePort, ProdutoPersistenceAdapter>();
            services.AddTransient<ICategoriaProdutoPersistencePort, CategoriaProdutoPersistenceAdapter>();
            
            services.AddTransient<IUsuarioPersistencePort, UsuarioPersistenceAdapter>();

            return services;
        }
    }
}
